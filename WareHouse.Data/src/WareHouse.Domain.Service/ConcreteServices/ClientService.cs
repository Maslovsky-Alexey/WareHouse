using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Context;
using WareHouse.Data.EF.Context.Mapping;
using WareHouse.Data.EF.Repository;
using WareHouse.Data.Model;
using WareHouse.Domain.Model;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.ServiceInterfaces;

namespace WareHouse.Domain.Service.ConcreteServices
{

    public class ClientService : BaseService<Domain.Model.Client, Data.Model.Client>, IClientService
    {
        public ClientService(BaseRepository<Data.Model.Client> repository) : base(repository, 
            new ModelsMapper<Data.Model.Client, Domain.Model.Client>(new ClientMapConfigurator()))
        {
         
        }

        public async Task<Model.Client> GetClientByName(string name, bool ignoreCase)
        {
            return MapToServiceModel(await ((ClientRepository)repository).GetClientByName(name, ignoreCase));
        }

        public async Task AddWithoutRepetition(Model.Client value)
        {
            var client = await GetClientByName(value.Name, true);

            if (client != null)
                return;

            await Add(value);
        }

        public async Task RemoveClientByName(Model.Client value)
        {
            var removingItem = await GetClientByName(value.Name, true);

            if (removingItem != null)
                await Remove(await GetItem(removingItem.Id));
        }

        public async Task<Model.Client> GetClientByIdentityId(string identityId)
        {
            return MapToServiceModel(await((ClientRepository)repository).GetClientByIdentityId(identityId));
        }
    }
}
