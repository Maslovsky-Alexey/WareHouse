using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IWarehouseItemService : IService<Domain.Model.WarehouseItem, Data.Model.WarehouseItem>
    {
        Task<IEnumerable<Model.ViewModel.WarehouseItemViewModel>> GetAllAsViewModel();

        Task AddOrUpdateAsViewModel(Model.ViewModel.WarehouseItemViewModel model);

        Task<IEnumerable<Model.WarehouseItem>> GetItemsByName(string name, bool ignoreCase);

        Task UpdateStatus(int itemId, int itemStatusId);
    }
}
