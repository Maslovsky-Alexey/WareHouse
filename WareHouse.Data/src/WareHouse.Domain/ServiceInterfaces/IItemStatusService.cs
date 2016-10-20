using System.Threading.Tasks;
using WareHouse.Data.Model;
using ItemStatus = WareHouse.Domain.Model.ItemStatus;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IItemStatusService : IService<ItemStatus, Data.Model.ItemStatus>
    {
        Task<ItemStatus> GetStatus(Status status);
    }
}