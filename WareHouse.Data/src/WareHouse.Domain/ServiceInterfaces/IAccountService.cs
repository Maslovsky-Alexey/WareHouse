using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.ServiceInterfaces.Unsafe;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IAccountService : ISafeAccountService, IUnsafeAccountService
    {
    }
}