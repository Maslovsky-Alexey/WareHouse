using System.Threading.Tasks;
using WareHouse.Domain.Model;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IClientService : IService<Client, Data.Model.Client>
    {
        Task<Client> GetClientByName(string name, bool ignoreCase);

        Task<bool> AddWithoutRepetition(Client value);

        Task<bool> RemoveClientByName(Client value);

        Task<Client> GetClientByIdentityId(string identityId);
    }
}