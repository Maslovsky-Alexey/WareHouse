using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Domain.Service.ProxyServices.Cache
{
    public interface ICache
    {
        void AddOrUpdate(string key, object item);

        void Remove(string key);

        T Get<T>(string key) where T : class;

        void Clear();
    }
}
