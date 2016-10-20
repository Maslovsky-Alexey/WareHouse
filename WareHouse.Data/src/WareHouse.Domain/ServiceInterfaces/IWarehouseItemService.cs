using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.MyOData;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IWarehouseItemService : IService<WarehouseItem, Data.Model.WarehouseItem>
    {
        Task<PageModel> GetPage(int page, MyODataConfigurates config);

        Task<IEnumerable<WarehouseItemViewModel>> GetAllAsViewModel();

        Task AddOrUpdateAsViewModel(WarehouseItem model);

        Task<IEnumerable<WarehouseItem>> GetItemsByName(string name, bool ignoreCase);

        Task<WarehouseItemViewModel> GetItemByIdAsViewModel(int id);
    }
}