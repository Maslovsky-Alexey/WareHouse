using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.MyOData;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IWarehouseItemService : IService<Domain.Model.WarehouseItem, Data.Model.WarehouseItem>
    {
        Task<PageModel> GetPage(int page, MyODataConfigurates config);

        Task<IEnumerable<Model.ViewModel.WarehouseItemViewModel>> GetAllAsViewModel();

        Task AddOrUpdateAsViewModel(Model.WarehouseItem model);

        Task<IEnumerable<Model.WarehouseItem>> GetItemsByName(string name, bool ignoreCase);

        Task<WarehouseItemViewModel> GetItemByIdAsViewModel(int id);
    }
}
