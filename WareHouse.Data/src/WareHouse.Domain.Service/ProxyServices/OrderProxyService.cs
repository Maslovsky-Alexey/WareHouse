using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.Service.ConcreteServices;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.ServiceInterfaces.Safe;

namespace WareHouse.Domain.Service.ProxyServices
{
    public class OrderProxyService : IUnafeOrderService
    {
        private IUnafeOrderService safeOrderService;


        public OrderProxyService(IUnafeOrderService safeOrderService)
        {
            this.safeOrderService = safeOrderService;
        }


        public async Task<int> Count()
        {
            return await safeOrderService.Count();
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await safeOrderService.GetAll();
        }

        public async Task<IEnumerable<OrderViewModel>> GetAllAsViewModel()
        {
            return await safeOrderService.GetAllAsViewModel();
        }

        public async Task<IEnumerable<OrderViewModel>> GetClientOrders(string clientName)
        {
            return await safeOrderService.GetClientOrders(clientName);
        }

        public async Task<Order> GetItem(int id)
        {
            return await safeOrderService.GetItem(id);
        }
    }
}
