using System.Threading.Tasks;
using WareHouse.Data.Model;

namespace WareHouse.Data.Repository
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserByName(string name, bool ignoreCase);
    }
}