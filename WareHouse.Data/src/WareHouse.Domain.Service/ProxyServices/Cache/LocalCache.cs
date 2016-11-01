using System;
using Microsoft.Extensions.Caching.Memory;

namespace WareHouse.Domain.Service.ProxyServices.Cache
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

        public T Get<T>(string key)
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
    }
}
