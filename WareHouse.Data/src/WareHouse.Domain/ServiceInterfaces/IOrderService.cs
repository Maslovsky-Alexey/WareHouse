using System.Threading.Tasks;
using WareHouse.Domain.Model;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IOrderService : IService<Order, Data.Model.Order>
    {
        Task UpdateOrderStatus(int id, int statusId);
    }
}