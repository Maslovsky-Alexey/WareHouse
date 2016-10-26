using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;

namespace WareHouse.Domain.ServiceInterfaces.Safe
{
    public interface IUnafeOrderService : ISafeService<Order, Data.Model.Order>
    {
        Task<IEnumerable<OrderViewModel>> GetClientOrders(string clientName);

        Task<IEnumerable<OrderViewModel>> GetAllAsViewModel();
    }
}
