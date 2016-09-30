using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.ServiceInterfaces;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class ItemStatusService : BaseService<Domain.Model.ItemStatus, Data.Model.ItemStatus>, IItemStatusService
    {
        IItemStatusRepository itemStatusRepository;

        public ItemStatusService(BaseRepository<Data.Model.ItemStatus> repository) : base(repository, 
            new ModelsMapper<Data.Model.ItemStatus, Domain.Model.ItemStatus>(new ItemStatusMapConfigurator()))
        {
            itemStatusRepository = (IItemStatusRepository)repository;
        }

        public async Task<Model.ItemStatus> GetStatus(Status status)
        {
            var result = await itemStatusRepository.GetStatus(status);

            if (result == null)
                return null;

            return MapToServiceModel(result);
        }
    }
}
