using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.MyOData;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class WarehouseItemService : BaseService<Domain.Model.WarehouseItem, Data.Model.WarehouseItem>, IWarehouseItemService
    {
        IWarehouseItemRepository warehouseItemRepository;
        IItemService itemService;
        IItemStatusService statusService;

        public WarehouseItemService(BaseRepository<Data.Model.WarehouseItem> repository, IItemService itemService, IItemStatusService statusService) : base(repository, 
            new ModelsMapper<Data.Model.WarehouseItem, Domain.Model.WarehouseItem>(new WarehouseItemMapConfigurator()))
        {
            warehouseItemRepository = (IWarehouseItemRepository)repository;
            this.itemService = itemService;
            this.statusService = statusService;
        }

        public async Task AddOrUpdateAsViewModel(Model.WarehouseItem model)
        {
            var item = (await GetItemsByName(model.Item.Name, true)).FirstOrDefault();

            if (item != null)
            {
                item.Count = model.Count;
            }
            else
            {
                await Add(model);
            }
        }

        public async Task<IEnumerable<WarehouseItemViewModel>> GetAllAsViewModel()
        {
            return (await ((WarehouseItemRepository) repository).GetAll())
                .Select(MapToViewModel);
        }

        public async Task<IEnumerable<Model.WarehouseItem>> GetItemsByName(string name, bool ignoreCase)
        {
            return (await((WarehouseItemRepository)repository).GetItemsByName(name, ignoreCase)).Select(MapToServiceModel);
        }


        public async Task<PageModel> GetPage(int page, MyODataConfigurates config)
        {
            var filter = MyOData.MyOData.CompileFilters<Data.Model.WarehouseItem>(config);

            IEnumerable<WarehouseItemViewModel> items = (await repository.GetAllWithFilter(filter))
                .Select(MapToViewModel);

            if (!items.Any())
                return new PageModel();

            items = MyOData.MyOData.OrderBy<WarehouseItemViewModel>(items, config);

            return GetPage(items, page);
        }

        private PageModel GetPage(IEnumerable<WarehouseItemViewModel> items, int page)
        {
            var result = new PageModel();

            result.Items = (items.Skip(page * 6).Take(6));

            result.PrevPage = GetPrevPage(page);
            result.NextPage = GetNextPage(page, items.Count());
            result.Max = items.Max(item => item.Count);
            result.Min = items.Min(item => item.Count);

            return result;
        }

        public async Task<WarehouseItemViewModel> GetItemByIdAsViewModel(int id)
        {
            return MapToViewModel(await repository.GetItem(id));
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
            var maxPage = (count - 1) / 6;
            return page + 1 > maxPage ? maxPage : page + 1;
        }
    }
}
