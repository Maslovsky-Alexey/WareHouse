using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.Service.ConcreteServices;
using WareHouse.Domain.Service.ProxyServices.Cache;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.ServiceInterfaces.Safe;

namespace WareHouse.Domain.Service.ProxyServices
{
    public class OrderProxyService : BaseProxyService<Order, Data.Model.Order>, ISafeOrderService
    {
        private ISafeOrderService safeOrderService;

        public OrderProxyService(ISafeService<Model.Order, Data.Model.Order> safeService, ICache cache) : base(safeService, cache)
        {
            this.safeOrderService = (ISafeOrderService)safeService;
        }

        public async Task<IEnumerable<OrderViewModel>> GetAllAsViewModel()
        {
            var items = cache.Get<IEnumerable<OrderViewModel>> ($"all");

            if (items != null)
                return items;

            items = await safeOrderService.GetAllAsViewModel();
            cache.AddOrUpdate($"all", items);
            return items;
        }

        public async Task<IEnumerable<OrderViewModel>> GetClientOrders(string clientName)
        {
            var items = cache.Get<IEnumerable<OrderViewModel>>($"all{clientName}");

            if (items != null)
                return items;

            items = await safeOrderService.GetClientOrders(clientName);
            cache.AddOrUpdate($"all{clientName}", items);
            return items;
        }
    }
}
