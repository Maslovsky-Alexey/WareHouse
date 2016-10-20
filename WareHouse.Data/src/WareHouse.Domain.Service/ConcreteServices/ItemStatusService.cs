using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.ServiceInterfaces;
using ItemStatus = WareHouse.Domain.Model.ItemStatus;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class ItemStatusService : BaseService<ItemStatus, Data.Model.ItemStatus>, IItemStatusService
    {
        private readonly IItemStatusRepository itemStatusRepository;

        public ItemStatusService(BaseRepository<Data.Model.ItemStatus> repository) : base(repository,
            new ModelsMapper<Data.Model.ItemStatus, ItemStatus>(new ItemStatusMapConfigurator()))
        {
            itemStatusRepository = (IItemStatusRepository) repository;
        }

        public async Task<ItemStatus> GetStatus(Status status)
        {
            var result = await itemStatusRepository.GetStatus(status);

            if (result == null)
                return null;

            return MapToServiceModel(result);
        }
    }
}