using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.ServiceInterfaces;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class ItemService : BaseService<Item, Data.Model.Item>, IItemService
    {
        public ItemService(BaseRepository<Data.Model.Item> repository) : base(repository,
            new ModelsMapper<Data.Model.Item, Item>(new ItemMapConfigurator()))
        {
        }

        public async Task AddWithoutRepetition(Item model)
        {
            var item = await GetItemByName(model.Name, true);

            if (item != null)
                return;

            await Add(model);
        }

        public async Task<Item> GetItemByName(string name, bool ignoreCase)
        {
            return MapToServiceModel(await ((ItemRepository) repository).GetItemByName(name, ignoreCase));
        }
    }
}