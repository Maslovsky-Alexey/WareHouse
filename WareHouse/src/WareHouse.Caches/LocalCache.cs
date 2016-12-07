using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace WareHouse.Caches
{
    public class LocalCache : ICache
    {
        protected MemoryCache memoryCache;

        public LocalCache()
        {
            memoryCache = new MemoryCache(new MemoryCacheOptions { });
        }

        public void AddOrUpdate(string key, object item)
        {
            memoryCache.Set(key, item);
        }

        public T Get<T>(string key) where T : class
        {
            return memoryCache.Get<T>(key);
        }

        public void Remove(string key)
        {
            memoryCache.Remove(key);
        }

        public void Clear()
        {
            memoryCache = new MemoryCache(new MemoryCacheOptions { });
        }

        public IEnumerable<string> GetAllKeys()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync<T>(string key) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetAllKeysAsync()
        {
            throw new NotImplementedException();
        }
    }
}
