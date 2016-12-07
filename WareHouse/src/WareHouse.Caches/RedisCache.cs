using StackExchange.Redis;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace WareHouse.Caches
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

        public T Get<T>(string key) where T : class
        {
            var value = database.StringGet(key);

            if (value.IsNullOrEmpty)
                return null;
            else
                return JsonConvert.DeserializeObject<T>(value);
        }

        public IEnumerable<string> GetAllKeys()
        {
            return server.Keys(dbIndex).Select(x => (string)x);
        }

        public void AddOrUpdate(string key, object item)
        {
            database.StringSet(key, JsonConvert.SerializeObject(item));
        }

        public void Remove(string key)
        {
            database.KeyDelete(key);
        }

        public void Clear()
        {
            server.FlushDatabase(dbIndex);
        }

        public async Task<T> GetAsync<T>(string key) where T : class
        {
            var value = await database.StringGetAsync(key);

            if (value.IsNullOrEmpty)
                return null;
            else
                return JsonConvert.DeserializeObject<T>(value);
        }

        public async Task<IEnumerable<string>> GetAllKeysAsync()
        {
            return await Task.Factory.StartNew(
                () => server.Keys(dbIndex).Select(x => (string)x)
            );
        }
    }
}
