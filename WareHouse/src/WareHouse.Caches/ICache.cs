using System.Collections.Generic;
using System.Threading.Tasks;

namespace WareHouse.Caches
{
    public interface ICache
    {
        void AddOrUpdate(string key, object item);

        void Remove(string key);

        T Get<T>(string key) where T : class;

        IEnumerable<string> GetAllKeys();

        Task<T> GetAsync<T>(string key) where T : class;

        Task<IEnumerable<string>> GetAllKeysAsync();

        void Clear();
    }
}
