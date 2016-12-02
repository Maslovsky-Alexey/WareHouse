using System.Threading.Tasks;
using WareHouse.Data.Model;

namespace WareHouse.Data.Repository
{
    public interface ISupplyRepository : IRepository<Supply>
    {
        Task UpdateSupplyStatus(int id, int statusId);
    }
}