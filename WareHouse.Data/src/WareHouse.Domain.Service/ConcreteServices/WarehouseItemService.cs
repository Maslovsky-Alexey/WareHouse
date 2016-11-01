using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.MyOData;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class WarehouseItemService : BaseService<WarehouseItem, Data.Model.WarehouseItem>, IWarehouseItemService
    {
        private readonly IWarehouseItemRepository warehouseItemRepository;

        public WarehouseItemService(BaseRepository<Data.Model.WarehouseItem> repository, IMapConfigurator mapConfigurator) : base(repository,
            new ModelsMapper<Data.Model.WarehouseItem, WarehouseItem>(mapConfigurator))
        {
            warehouseItemRepository = (IWarehouseItemRepository) repository;
        }

        public async Task AddOrUpdate(WarehouseItem model)
        {
            var item = await GetItemByName(model.Item.Name, false);

            if (item == null)
            {
                await Add(model);
                return;
            }
            
            await UpdateCount(item.Id, model.Count);
            OnNext(null);
        }

        public async Task UpdateCount(int warehouseItemId, int deltaCount)
        {
            await warehouseItemRepository.UpdateCount(warehouseItemId, deltaCount);
            OnNext(null);
        }

        public async Task<IEnumerable<WarehouseItemViewModel>> GetAllAsViewModel()
        {
            return (await ((WarehouseItemRepository) repository).GetAll())
                .Select(MapToViewModel);
        }

        public async Task<WarehouseItem> GetItemByName(string name, bool ignoreCase)
        {
            return
               MapToServiceModel(await ((WarehouseItemRepository) repository).GetItemByName(name, ignoreCase));
        }


        public async Task<PageModel> GetPage(int page, MyODataConfigurates config)
        {
            var filter = MyOData.MyOData.CompileFilters<Data.Model.WarehouseItem>(config);

            var items = (await repository.GetAllWithFilter(filter))
                .Select(MapToViewModel);

            if (!items.Any())
                return new PageModel();

            items = MyOData.MyOData.OrderBy(items, config);

            return GetPage(items, page);
        }

        public async Task<WarehouseItemViewModel> GetItemByIdAsViewModel(int id)
        {
            return MapToViewModel(await repository.GetItem(id));
        }

        private PageModel GetPage(IEnumerable<WarehouseItemViewModel> items, int page)
        {
            return new PageModel
            {
                Items = items.Skip(page*6).Take(6),
                PrevPage = GetPrevPage(page),
                NextPage = GetNextPage(page, items.Count()),
                Max = items.Max(item => item.Count),
                Min = items.Min(item => item.Count)
            };
        }

        private WarehouseItemViewModel MapToViewModel(Data.Model.WarehouseItem item)
        {
            return new WarehouseItemViewModel
            {
                Count = item.Count,
                ItemId = item.ItemId,
                Name = item.Item.Name
            };
        }

        private int GetPrevPage(int page)
        {
            return page - 1 < 0 ? 0 : page - 1;
        }

        private int GetNextPage(int page, int count)
        {
            var maxPage = (count - 1)/6;
            return page + 1 > maxPage ? maxPage : page + 1;
        }
    }
}