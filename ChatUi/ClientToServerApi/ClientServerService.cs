using ClientToServerApi.Models.Enums.Transmissions;
using ClientToServerApi.Models.TransmissionModels;
using ClientToServerApi.Serializer;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;

namespace ClientToServerApi
{
    public class ClientServerService
    {
        private readonly TcpClient tcpClient_;
        private readonly NetworkStream networkStream_;
        private readonly DataManager dataManager_;
        static JsonStringSerializer serializer = new JsonStringSerializer();
        private static Thread receiveThread_;
        private static ClientServerService clientServerService_;
        private static string ServerIp { set; get; }
        private static string ServerPort { set; get; }
        private readonly Logger logger =  LogManager.GetCurrentClassLogger();
        static Encoder encoder;
        private ClientServerService()
        {
            tcpClient_ = new TcpClient();
            dataManager_ = new DataManager();
            networkStream_ = Connect(ServerIp, ServerPort);
            encoder = new Encoder();
        }

        #region DataManagerRegion 
        public void AddListener(ListenerType key, Handler listener) => dataManager_.AddListener(key, listener);
        public void RemoveListener(ListenerType key) => dataManager_.RemoveListener(key);
        #endregion

        public static void SetApiConfig(string serverIp, string serverPort)
        {
            ServerIp = serverIp;
            ServerPort = serverPort;
        }

        public static ClientServerService GetInstanse()
        {
            if (clientServerService_ == null)
                clientServerService_ = new ClientServerService();
            return clientServerService_;
        }

        ~ClientServerService()
        {
            tcpClient_.Close();
            if(networkStream_ != null)
                networkStream_.Close();
        }

        public void CloseConnection()
        {
            tcpClient_.Close();
        }

        public static void ShutdownReceiving() => receiveThread_.Abort();

        private NetworkStream Connect(string ServerIp, string ServerPort)
        {
            try
            {
                tcpClient_.ConnectAsync(IPAddress.Parse(ServerIp), Convert.ToInt32(ServerPort)).Wait();
                if (tcpClient_.Connected)
                {
                    receiveThread_ = new Thread(ReceiveData);
                    receiveThread_.Start();
                    return tcpClient_.GetStream();
                }
            }
            catch (Exception)
            {
               MessageBox.Show("Не удалось установить соединение с сервером!");
            }
            logger.Warn("Не удалось установить соединение с сервером!");
            throw new Exception("Не удалось установить соединение с сервером!");
        }

        public async void SendAsync(ClientOperationMessage clientOperationMessage)
        {
            try
            {
                logger.Info($"Send message to server: Operation = {clientOperationMessage.Operation} JsonData = {clientOperationMessage.JsonData}");

                byte[] binary_data = encoder.Encryption(serializer.Serialize(clientOperationMessage));
                await networkStream_.WriteAsync(binary_data, 0, binary_data.Length).ConfigureAwait(false);
            }
            catch(Exception) 
            {
                MessageBox.Show("Не удалось отправить запрос на сервер");
                logger.Warn("Не удалось отправить запрос на сервере");
                throw new Exception("Не удалось отправить запрос на сервер");
                
            }
        }

        private void ReceiveData()
        {
            try
            {
                byte[] buffer = new byte[1024];
                List<byte> byteMessage = new List<byte>();
                while (true)
                {
                    do
                    {
                        int count = networkStream_.Read(buffer, 0, 256);

                        for (int i = 0; i < count; i++)
                        {
                            byteMessage.Add(buffer[i]);
                        }
                    } while (networkStream_.DataAvailable);

                    try
                    {
                        var obj = serializer.Deserialize<OperationResultInfo>(encoder.Decryption(byteMessage.ToArray()));
                        byteMessage.Clear();
                        dataManager_.HandleData(obj.ToListener, obj);
                    }
                    catch (Exception ex) 
                    {
                        logger.Warn($"Error {ex.Message}");
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось получить данные с сервера!");
                logger.Warn("не удалось получить данные с сервера!");
                throw new Exception("Не удалось получить данные с сервера!");
            }
        }
    }
}
