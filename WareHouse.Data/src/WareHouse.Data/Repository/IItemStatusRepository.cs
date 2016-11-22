using System.Threading.Tasks;
using WareHouse.Data.Model;

namespace WareHouse.Data.Repository
{
    public interface IItemStatusRepository : IRepository<ItemStatus>
    {
        Task<ItemStatus> GetStatus(Status status);
    }
}