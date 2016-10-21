using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IOrderService : IService<Order, Data.Model.Order>
    {
        Task UpdateOrderStatus(int id, int statusId);

        Task<IEnumerable<OrderViewModel>> GetClientOrders(string clientName);

        Task<IEnumerable<OrderViewModel>> GetAllAsViewModel();
    }
}