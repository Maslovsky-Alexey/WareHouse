using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouse.Data.Model;

namespace WareHouse.Data.Repository
{
    public interface IWarehouseItemRepository : IRepository<WarehouseItem>
    {
        Task<WarehouseItem> GetItemByName(string name, bool ignoreCase);

        Task<bool> UpdateCount(int warehouseItemId, int deltaCount);
    }
}