using System;
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
        public ClientService(BaseRepository<Data.Model.Client> repository, IMapConfigurator mapConfigurator) : base(repository,
            new ModelsMapper<Data.Model.Client, Client>(mapConfigurator))
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

            if (await Add(value) == Data.Repository.OperationStatus.Added)
                OnNext(value);

            return true;
        }

        public async Task<bool> RemoveClientByName(Client value)
        {
            var removingItem = await GetClientByName(value.Name, true);

            if (removingItem == null)
                return false;

            if (await Remove(await GetItem(removingItem.Id)) == Data.Repository.OperationStatus.Removed)
                OnNext(null);

            return true;
        }

        public async Task<Client> GetClientByIdentityId(string identityId)
        {
            return MapToServiceModel(await ((ClientRepository) repository).GetClientByIdentityId(identityId));
        }



        public async Task<Client> AddOrAssignWithApplicationUser(string clientName, string userId)
        {
            var client = await GetClientByName(clientName, false);

            if (client == null)
            {
                await Add(new Client { Name = clientName, UserId = userId });

                return await GetClientByName(clientName, false);
            }
            else
            {
                var result = MapToServiceModel(await ((ClientRepository)repository).AssignWithApplicationUser(client.Id, userId));

                if (result != null)
                    OnNext(result);

                return result;
            }
        }
    }
}