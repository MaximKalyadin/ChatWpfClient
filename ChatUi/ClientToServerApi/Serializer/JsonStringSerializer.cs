using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ClientToServerApi.Serializer
{
    public class JsonStringSerializer
    {
        private readonly JsonSerializerOptions _options;

        public JsonStringSerializer()
        {
            _options = new JsonSerializerOptions { IgnoreNullValues = true };
        }

        /// <summary>
        /// Deserialize JSON string to T object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">JSON string</param>
        /// <returns>T object</returns>
        //public T Deserialize<T>(string obj) where T : class, new() => JsonConvert.DeserializeObject<T>(obj);

        public T Deserialize<T>(string obj) where T : class, new() => JsonSerializer.Deserialize<T>(obj, _options);

        /// <summary>
        /// Serialize T object to JSON string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        //public string Serialize<T>(T obj) where T : class, new() => JsonConvert.SerializeObject(obj);

        public string Serialize<T>(T obj) where T : class, new() => JsonSerializer.Serialize(obj, _options);
    }
}
