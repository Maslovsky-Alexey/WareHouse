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
        public ClientService(BaseRepository<Data.Model.Client> repository) : base(repository,
            new ModelsMapper<Data.Model.Client, Client>(new ClientMapConfigurator())) // TODO: Почему эти параметры указаны явно, а не в DI контейнере?
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

        public async Task<Client> AssignWithApplicationUser(int clientId, string userId)
        {
            var a = MapToServiceModel(await ((ClientRepository)repository).AssignWithApplicationUser(clientId, userId));

            if (a != null)
                OnNext(a);

            return a;
        }
    }
}