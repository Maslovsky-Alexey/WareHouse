using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace WareHouse.Domain.Service.ProxyServices.Cache
{
    public class RedisCache : ICache
    {
        private ConnectionMultiplexer redis;
        private IServer server;
        private IDatabase database;
        private int dbIndex;

        public RedisCache(string url, int dbIndex)
        {
            redis = ConnectionMultiplexer.Connect($"{url}, allowAdmin=true");

            server = redis.GetServer(url);
            database = redis.GetDatabase(dbIndex);
            this.dbIndex = dbIndex;
        }

        public void AddOrUpdate(string key, object item)
        {
            database.StringSet(key, JsonConvert.SerializeObject(item));
        }

        public void Clear()
        {
            server.FlushDatabase(dbIndex);
        }

        public T Get<T>(string key) where T : class
        {
            T result = null;

            try
            {
                var a = database.StringGet(key);
                var b = JsonConvert.DeserializeObject<T>(a);
                result = b;
            }
            catch
            {
                
            }

            return result;
        }

        public void Remove(string key)
        {
            database.KeyDelete(key);
        }
    }
}
