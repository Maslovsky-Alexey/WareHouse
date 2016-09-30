using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.Model;

namespace WareHouse.Data.Repository
{
    public interface IWarehouseItemRepository : IRepository<Model.WarehouseItem>
    {
        Task<IEnumerable<WarehouseItem>> GetItemsByName(string name, bool ignoreCase);

        Task UpdateStatus(int itemId, int itemStatusId);
    }
}
