using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Service.ConcreteServices;
using WareHouse.Domain.Service.ProxyServices.Cache;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.ServiceInterfaces.Safe;

namespace WareHouse.Domain.Service.ProxyServices
{
    public class ItemProxyService : ISafeItemService, IObserver<Item>
    {
        private ISafeItemService safeItemService;
        private ICache cache;

        public ItemProxyService(ISafeItemService safeItemService, ICache cache)
        {
            this.safeItemService = safeItemService;
            this.cache = cache;
        }

        public async Task<int> Count()
        {
            return await safeItemService.Count();
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            var items = (IEnumerable<Item>)cache.Get("all");

            if (items != null)
                return items;

            items = await safeItemService.GetAll();
            cache.AddOrUpdate("all", items);

            return items;
        }

        public async Task<Item> GetItem(int id)
        {
            return await safeItemService.GetItem(id);
        }

        public async Task<Item> GetItemByName(string name, bool ignoreCase)
        {
            return await safeItemService.GetItemByName(name, ignoreCase);
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Item value)
        {
            cache.Clear();
        }
    }
}
