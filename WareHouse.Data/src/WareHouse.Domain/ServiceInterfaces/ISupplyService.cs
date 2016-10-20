using System.Threading.Tasks;
using WareHouse.Domain.Model;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface ISupplyService : IService<Supply, Data.Model.Supply>
    {
        Task UpdateSupplyStatus(int id, int statusId);
    }
}