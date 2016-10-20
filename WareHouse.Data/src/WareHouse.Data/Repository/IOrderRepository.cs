using System.Threading.Tasks;
using WareHouse.Data.Model;

namespace WareHouse.Data.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task UpdateOrderStatus(int id, int statusId);
    }
}