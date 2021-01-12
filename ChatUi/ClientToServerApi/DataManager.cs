using ClientToServerApi.Models.Enums.Transmissions;
using ClientToServerApi.Models.TransmissionModels;
using NLog;
using System;
using System.Collections.Generic;

namespace ClientToServerApi
{
    public delegate void Handler(OperationResultInfo data);
    public class DataManager
    { 
        private Dictionary<ListenerType, Handler> listenerDict_;
        private readonly Logger loger = LogManager.GetCurrentClassLogger();
        public DataManager() => listenerDict_ = new Dictionary<ListenerType, Handler>();
        public void AddListener(ListenerType key, Handler listener) => listenerDict_.Add(key, listener);
        public void RemoveListener(ListenerType key) => listenerDict_.Remove(key);
        public void HandleData(ListenerType key, OperationResultInfo data)
        {
            if (listenerDict_.ContainsKey(key))
            {
                //parse data (string) to object;
                
                listenerDict_[key].Invoke(data);
            }
            else
                throw new Exception("This key isn't contains in listener dictionary");
            loger.Warn($"This key isn't contains in listener dictionary");
        }
    }
}
