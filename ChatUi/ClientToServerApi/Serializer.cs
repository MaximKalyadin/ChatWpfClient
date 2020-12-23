using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientToServerApi
{
    public class Serializer
    {
        /// <summary>
        /// Deserialize JSON string to T object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">JSON string</param>
        /// <returns>T object</returns>
        public T Deserialize<T>(string obj) where T : class, new() => JsonConvert.DeserializeObject<T>(obj);

        /// <summary>
        /// Serialize T object to JSON string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string Serialize<T>(T obj) where T : class, new() => JsonConvert.SerializeObject(obj);
    }
}
