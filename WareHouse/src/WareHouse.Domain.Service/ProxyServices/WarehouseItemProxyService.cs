using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.Service.ConcreteServices;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.MyOData;

namespace WareHouse.Domain.Service.ProxyServices
{
    public class WarehouseItemProxyService : ISafeWarehouseItemService
    {
        private ISafeWarehouseItemService safeWarehouseItemService;


        public WarehouseItemProxyService(ISafeWarehouseItemService safeWarehouseItemService)
        {
            this.safeWarehouseItemService = safeWarehouseItemService;
        }

        public async Task<int> Count()
        {
            return await safeWarehouseItemService.Count();
        }

        public async Task<IEnumerable<WarehouseItem>> GetAll()
        {
            return await safeWarehouseItemService.GetAll();
        }

        public async Task<IEnumerable<WarehouseItemViewModel>> GetAllAsViewModel()
        {
            return await safeWarehouseItemService.GetAllAsViewModel();
        }

        public async Task<WarehouseItem> GetItem(int id)
        {
            return await safeWarehouseItemService.GetItem(id);
        }

        public async Task<WarehouseItemViewModel> GetItemByIdAsViewModel(int id)
        {
            return await safeWarehouseItemService.GetItemByIdAsViewModel(id);
        }

        public async Task<WarehouseItem> GetItemByName(string name, bool ignoreCase)
        {
            return await safeWarehouseItemService.GetItemByName(name, ignoreCase);
        }

        public async Task<PageModel> GetPage(int page, MyODataConfigurates config)
        {
            return await safeWarehouseItemService.GetPage(page, config);
        }
    }
}
