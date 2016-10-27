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
    public class ItemProxyService : BaseProxyService<Item, Data.Model.Item>, ISafeItemService
    {
        private ISafeItemService safeItemService;

        public ItemProxyService(ISafeService<Model.Item, Data.Model.Item> safeService, ICache cache) : base(safeService, cache)
        {
            safeItemService = (ISafeItemService)safeService;
        }

        public async Task<Item> GetItemByName(string name, bool ignoreCase)
        {
            var item = (Item)cache.Get($"^item{name}");

            if (item != null)
                return item;


            item = await safeItemService.GetItemByName(name, ignoreCase);
            cache.AddOrUpdate($"^item{name}", item);
            return item;
        }
    }
}
