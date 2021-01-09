using ClientToServerApi.Models.Enums.Transmissions;
using ClientToServerApi.Models.TransmissionModels;
using System;
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
        private Serializer serializer = new Serializer();
        private static Thread receiveThread_;
        private static ClientServerService clientServerService_;
        private static string ServerIp { set; get; }
        private static string ServerPort { set; get; }

        private ClientServerService()
        {
            tcpClient_ = new TcpClient();
            dataManager_ = new DataManager();
            networkStream_ = Connect(ServerIp, ServerPort);
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

            throw new Exception("Не удалось установить соединение с сервером!");
        }

        public async void SendAsync(ClientOperationMessage clientOperationMessage)
        {
            try
            {
                byte[] binary_data = Encoding.UTF8.GetBytes(serializer.Serialize(clientOperationMessage));
                await networkStream_.WriteAsync(binary_data, 0, binary_data.Length).ConfigureAwait(false);
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось отправить запрос на сервер");
                throw new Exception("Не удалось отправить запрос на сервер");
            }
        }

        private void ReceiveData()
        {
            try
            {
                byte[] buffer = new byte[1024];
                
                while (true)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    do
                    {
                        int count = networkStream_.Read(buffer, 0, 1024);
                        stringBuilder.Append(Encoding.UTF8.GetString(buffer, 0, count));
                    } while (networkStream_.DataAvailable);

                    try
                    {
                        var obj = serializer.Deserialize<OperationResultInfo>(stringBuilder.ToString());
                        
                        dataManager_.HandleData(obj.ToListener, obj);
                        stringBuilder.Clear();
                    }
                    catch (Exception ex) 
                    { 
                        Debug.WriteLine(ex.Message); 
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось получить данные с сервера!");
                throw new Exception("Не удалось получить данные с сервера!");
            }
        }
    }
}
