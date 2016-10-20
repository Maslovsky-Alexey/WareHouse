using System.Threading.Tasks;
using WareHouse.Data.Model;

namespace WareHouse.Data.Repository
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client> GetClientByName(string name, bool ignoreCase);

        Task<Client> GetClientByIdentityId(string identityId);
    }
}