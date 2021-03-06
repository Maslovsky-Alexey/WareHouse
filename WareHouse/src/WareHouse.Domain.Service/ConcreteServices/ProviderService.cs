﻿using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.ServiceInterfaces;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class ProviderService : BaseService<Provider, Data.Model.Provider>, IProviderService
    {
        public ProviderService(BaseRepository<Data.Model.Provider> repository, IMapConfigurator mapConfigurator) : base(repository,
            new ModelsMapper<Data.Model.Provider, Provider>(mapConfigurator))
        {
        }

        public async Task<Provider> GetProviderByName(string name, bool ignoreCase)
        {
            return MapToServiceModel(await ((ProviderRepository) repository).GetProviderByName(name, ignoreCase));
        }

        public async Task AddWithoutRepetition(Provider value)
        {
            var provider = await GetProviderByName(value.Name, true);

            if (provider != null)
                return;

            if (await Add(value) == Data.Repository.OperationStatus.Added)
                OnNext(value);
        }

        public async Task RemoveProviderByName(Provider value)
        {
            var removingItem = await GetProviderByName(value.Name, true);

            if (removingItem != null)
                if (await Remove(await GetItem(removingItem.Id)) == Data.Repository.OperationStatus.Removed)
                    OnNext(null);
        }
    }
}