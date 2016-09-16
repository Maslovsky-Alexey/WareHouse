using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class ItemService : BaseService<Domain.Model.Item, Data.Model.Item>
    {
        public ItemService(BaseRepository<Data.Model.Item> repository) : base(repository)
        {

        }

        protected override Data.Model.Item MapToEFModel(Domain.Model.Item model)
        {
            return new ModelsMapper.ItemMapper().MapEF(model);
        }

        protected override Domain.Model.Item MapToServiceModel(Data.Model.Item model)
        {
            return new ModelsMapper.ItemMapper().MapService(model);
        }

        public async Task<Model.Item> GetItemByName(string name)
        {
            return MapToServiceModel(await((ItemRepository)repository).GetItemByName(name));
        }
        public async Task<Model.Item> GetItemByNameIgnoreCase(string name)
        {
            return MapToServiceModel(await ((ItemRepository)repository).GetItemByNameIgnoreCase(name));
        }

        public async Task UpdateCount(int itemID, int newCount)
        {
            var item = await repository.GetItem(itemID);
            item.Count = newCount;

            await repository.SaveChanges();
        }
    }
}
