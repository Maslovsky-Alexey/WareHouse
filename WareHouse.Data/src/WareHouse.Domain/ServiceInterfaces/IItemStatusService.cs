using System.Threading.Tasks;
using WareHouse.Data.Model;
using ItemStatus = WareHouse.Domain.Model.ItemStatus;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.ServiceInterfaces.Unsafe;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IItemStatusService : ISafeItemStatusService, IUnsafeItemStatusService
    {
    }
}