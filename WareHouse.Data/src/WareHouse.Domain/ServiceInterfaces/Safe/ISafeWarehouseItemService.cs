using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.MyOData;

namespace WareHouse.Domain.ServiceInterfaces.Safe
{
    public interface ISafeWarehouseItemService : ISafeService<WarehouseItem, Data.Model.WarehouseItem>
    {
        Task<PageModel> GetPage(int page, MyODataConfigurates config);

        Task<IEnumerable<WarehouseItemViewModel>> GetAllAsViewModel();

        Task<WarehouseItem> GetItemByName(string name, bool ignoreCase);

        Task<WarehouseItemViewModel> GetItemByIdAsViewModel(int id);
    }
}
