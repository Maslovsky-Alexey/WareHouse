using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.Service.ElasticSearchProviders;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.MyOData;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class WarehouseItemService : BaseService<WarehouseItem, Data.Model.WarehouseItem>, IWarehouseItemService
    {
        private readonly IWarehouseItemRepository warehouseItemRepository;
        private readonly IElasticSearchtemProvider elasticSearchProvider;

        public WarehouseItemService(BaseRepository<Data.Model.WarehouseItem> repository, IMapConfigurator mapConfigurator, IElasticSearchtemProvider elasticSearchProvider) : base(repository,
            new ModelsMapper<Data.Model.WarehouseItem, WarehouseItem>(mapConfigurator))
        {
            warehouseItemRepository = (IWarehouseItemRepository) repository;
            this.elasticSearchProvider = elasticSearchProvider;
        }

        public async Task AddOrUpdate(WarehouseItem model)
        {
            var item = await GetItemByName(model.Item.Name, false);

            if (item == null)
            {
                await Add(model);
                elasticSearchProvider.AddUpdateEntity(MapToViewModel(model));
                return;
            }

            elasticSearchProvider.AddUpdateEntity(MapToViewModel(model));
            await UpdateCount(item.Id, model.Count);

            OnNext(null); 
        }

        public async Task UpdateCount(int warehouseItemId, int deltaCount)
        {
            await warehouseItemRepository.UpdateCount(warehouseItemId, deltaCount);
            OnNext(null);

            var a = await warehouseItemRepository.GetItem(warehouseItemId);
            var item = MapToServiceModel(await warehouseItemRepository.GetItem(warehouseItemId));
            elasticSearchProvider.AddUpdateEntity(MapToViewModel(item));
        }

        public async Task<IEnumerable<WarehouseItemViewModel>> GetAllAsViewModel()
        {
            return (await repository.GetAll())
                .Select(MapToViewModel);
        }

        public async Task<WarehouseItem> GetItemByName(string name, bool ignoreCase)
        {
            return MapToServiceModel(await (warehouseItemRepository.GetItemByName(name, ignoreCase)));
        }


        public async Task<PageModel> GetPage(int page, MyODataConfigurates config)
        {
            var search = GetAndRemoveSearchString(config);        

            var allItems = (await repository.GetAllWithFilter(config))
                .Select(MapToViewModel);

            var items = SearchItems(allItems, search);

            if (items == null || !items.Any())
                return new PageModel();

            return GetPage(items, page);
        }

        private string GetAndRemoveSearchString(MyODataConfigurates config)
        {
            var list = new List<PropertyFilter>(config.PropertiesFilter);
            var item = list.FirstOrDefault(x => x.Name == "search");
            var search = "";

            if (item != null)
            {
                search = item.Filter;
                list.Remove(item);
                config.PropertiesFilter = list;
            }

            return search;
        }

        private IEnumerable<WarehouseItemViewModel> SearchItems(IEnumerable<WarehouseItemViewModel> source, string searchString)
        {
            var items = new List<WarehouseItemViewModel>();

            foreach (var item in source)
            {
                elasticSearchProvider.AddUpdateEntity(item);
            }

            var searchItems = elasticSearchProvider.QueryString(searchString);

            if (searchItems == null)
                return null;

            foreach (var item in source)
            {
                var b = searchItems.FirstOrDefault(x => x.Id == item.Id);

                if (b != null)
                    items.Add(b);
            }

            return items;
        }

        public async Task<WarehouseItemViewModel> GetItemByIdAsViewModel(int id)
        {
            var item = await repository.GetItem(id);

            if (item == null)
                return null;

            return MapToViewModel(item);
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
                Name = item.Item.Name,
                Id = item.Id,
                Description = item.Item.Description
            };
        }

        private WarehouseItemViewModel MapToViewModel(Domain.Model.WarehouseItem item)
        {
            return new WarehouseItemViewModel
            {
                Count = item.Count,
                ItemId = item.ItemId,
                Name = item.Item.Name,
                Id = item.Id,
                Description = item.Item.Description
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