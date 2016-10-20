using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.ServiceInterfaces;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class ClientService : BaseService<Client, Data.Model.Client>, IClientService
    {
        public ClientService(BaseRepository<Data.Model.Client> repository) : base(repository,
            new ModelsMapper<Data.Model.Client, Client>(new ClientMapConfigurator()))
        {
        }

        public async Task<Client> GetClientByName(string name, bool ignoreCase)
        {
            return MapToServiceModel(await ((ClientRepository) repository).GetClientByName(name, ignoreCase));
        }

        public async Task<bool> AddWithoutRepetition(Client value)
        {
            var client = await GetClientByName(value.Name, true);

            if (client != null)
                return false;

            await Add(value);
            return true;
        }

        public async Task<bool> RemoveClientByName(Client value)
        {
            var removingItem = await GetClientByName(value.Name, true);

            if (removingItem == null)
                return false;

            await Remove(await GetItem(removingItem.Id));
            return true;
        }

        public async Task<Client> GetClientByIdentityId(string identityId)
        {
            return MapToServiceModel(await ((ClientRepository) repository).GetClientByIdentityId(identityId));
        }
    }
}