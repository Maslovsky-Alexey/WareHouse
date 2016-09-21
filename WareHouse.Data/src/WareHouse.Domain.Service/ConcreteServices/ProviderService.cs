using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.Model;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class ProviderService : BaseService<Domain.Model.Provider, Data.Model.Provider>, IProviderService
    {
        public ProviderService(BaseRepository<Data.Model.Provider> repository) : base(repository,
             new ModelsMapper<Data.Model.Provider, Domain.Model.Provider>(new ProviderMapConfigurator()))
        {

        }

        public async Task<Model.Provider> GetProviderByName(string name, bool ignoreCase)
        {
            return MapToServiceModel(await ((ProviderRepository)repository).GetProviderByName(name, ignoreCase));
        }

        public async Task AddWithoutRepetition(Model.Provider value)
        {
            var provider = await GetProviderByName(value.Name, true);

            if (provider != null)
                return;

            await Add(value);
        }

        public async Task RemoveProviderByName(Provider value)
        {
            var removingItem = await GetProviderByName(value.Name, true);

            if (removingItem != null)
                await Remove(await GetItem(removingItem.Id));
        }
    }
}
