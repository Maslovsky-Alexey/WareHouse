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

        public object Get(string key) // TODO: Сделать generic методом.
        {
            return memoryCache.Get<object>(key);
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
