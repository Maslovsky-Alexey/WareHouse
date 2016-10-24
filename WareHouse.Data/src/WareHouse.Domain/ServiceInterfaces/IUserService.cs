using System.Threading.Tasks;
using WareHouse.Data.Model;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.ServiceInterfaces.Unsafe;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserByName(string name, bool ignoreCase);
    }
}