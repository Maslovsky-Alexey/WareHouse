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

        public async Task AddOrUpdateAsViewModel(WarehouseItemViewModel model)
        {
            var item = (await GetItemsByName(model.Name, true)).FirstOrDefault(x => x.Status.Id == model.StatusId);

            if (item != null)
            {
                item.Item.Count = model.Count;
            }
            else
            {
                item = new Model.WarehouseItem();
                item.Item = new Model.Item { Name = model.Name };
                item.Count = model.Count;
                item.Status = new Model.ItemStatus { Id = model.StatusId, Name = model.Status };

                await Add(item);
            }
        }

        public async Task<IEnumerable<WarehouseItemViewModel>> GetAllAsViewModel()
        {
            return (await ((WarehouseItemRepository)repository).GetAll())
                .Select(async x => await MapToViewModel(x))
                .Select(x => x.Result);
        }

        public async Task<IEnumerable<Model.WarehouseItem>> GetItemsByName(string name, bool ignoreCase)
        {
            return (await((WarehouseItemRepository)repository).GetItemsByName(name, ignoreCase)).Select(item => MapToServiceModel(item));
        }

        public async Task UpdateStatus(int itemId, int itemStatusId)
        {
            await warehouseItemRepository.UpdateStatus(itemId, itemStatusId);
        }


        public async Task<PageModel> GetPage(int page, MyODataConfigurates config)
        {
            var filter = MyOData.MyOData.CompileFilters<Data.Model.WarehouseItem>(config);  // TODO: Спросить как реализовать фильтрацию по полю в поле (Нужно использовать не WarehouseItem а WarehouseItemViewModel ) Может нужно делат филтрацию не в репозитории ?? а для вью моделм ?

            var result = new PageModel();

            IEnumerable<WarehouseItemViewModel> items = (await repository.GetAllWithFilter(filter))
                .Select(async x => await MapToViewModel(x))
                .Select(x => x.Result);

            if (items.Count() == 0)
                return result;

            items = MyOData.MyOData.OrderBy<WarehouseItemViewModel>(items, config);

            result.Items = (items.Skip(page * 6).Take(6));

            result.PrevPage = GetPrevPage(page);
            result.NextPage = GetNextPage(page, items.Count());
            result.Max = items.Max(item => item.Count);
            result.Min = items.Min(item => item.Count);

            return result;
        }

        public async Task<WarehouseItemViewModel> GetItemByIdAsViewModel(int id)
        {
            return await MapToViewModel(await repository.GetItem(id));
        }

        private async Task<WarehouseItemViewModel> MapToViewModel(Data.Model.WarehouseItem item)
        {
            return new WarehouseItemViewModel
            {
                Count = item.Count,
                ItemId = item.ItemId,
                Name = (await itemService.GetItem(item.ItemId)).Name,
                StatusId = item.StatusId,
                Status = (await statusService.GetItem(item.StatusId)).Name
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
