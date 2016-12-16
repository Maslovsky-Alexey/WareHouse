using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.ServiceInterfaces;
using System.Reactive.Subjects;
using System;
using System.Collections.Generic;
using System.IO;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class ItemService : BaseService<Item, Data.Model.Item>, IItemService
    {
        private readonly string fileLocation;

        public ItemService(BaseRepository<Data.Model.Item> repository, IMapConfigurator mapConfigurator, string fileLocation) : base(repository,
            new ModelsMapper<Data.Model.Item, Item>(mapConfigurator))
        {
            this.fileLocation = fileLocation;
        }

        public async Task AddWithoutRepetition(Item model)
        {
            var item = await GetItemByName(model.Name, true);

            if (item != null)
                return;

            await Add(model);
        }

        protected override Data.Model.Item MapToEFModel(Model.Item model)
        {
            var fileName = $"{DateTime.Now.Ticks}_{model.Name}";
            File.WriteAllBytes(fileLocation + @"\" + fileName, Convert.FromBase64String(model.Base64));  // Вынести в отдельный класс

            return new Data.Model.Item
            {
                Description = model.Description,
                Name = model.Name,
                FileLocation = fileName
            };
        }

        public async Task<Item> GetItemByName(string name, bool ignoreCase)
        {
            return MapToServiceModel(await ((ItemRepository) repository).GetItemByName(name, ignoreCase));
        }
    }
}