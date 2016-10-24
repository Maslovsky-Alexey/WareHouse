using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.ServiceInterfaces.Unsafe;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IClientService : IService<Client, Data.Model.Client>, ISafeClientService, IUnsafeClientService
    {
    }
}