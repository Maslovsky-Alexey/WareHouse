using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouse.Data.Model;

namespace WareHouse.Data.Repository
{
    public interface IWarehouseItemRepository : IRepository<WarehouseItem>
    {
        Task<IEnumerable<WarehouseItem>> GetItemsByName(string name, bool ignoreCase);
    }
}