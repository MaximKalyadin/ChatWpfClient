using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClientToServerApi.Serializer
{
    public class JsonBinarySerializer
    {
        /// <summary>
        /// Deserializing from byte arr to T type
        /// </summary>
        /// <typeparam name="T">generic parameter</typeparam>
        /// <param name="obj">serialized object</param>
        /// <returns>deserialized object</returns>
        public T Deserialize<T>(byte[] obj) where T : class, new()
        {
            using (MemoryStream memoryStream = new MemoryStream(obj))
            {
                using (BsonDataReader bsonDataReader = new BsonDataReader(memoryStream))
                {
                    return (T)new JsonSerializer().Deserialize(bsonDataReader);
                }
            }
        }

        /// <summary>
        /// Serializing from T type instance to byte arr
        /// </summary>
        /// <typeparam name="T">generic parameter</typeparam>
        /// <param name="obj">T type instance</param>
        /// <returns>serialized instance</returns>
        public byte[] Serialize<T>(T obj) where T : class, new()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (BsonDataWriter bsonDataWriter = new BsonDataWriter(memoryStream))
                {
                    new JsonSerializer().Serialize(bsonDataWriter, obj);

                    return memoryStream.ToArray();
                }
            }
        }
    }
}
