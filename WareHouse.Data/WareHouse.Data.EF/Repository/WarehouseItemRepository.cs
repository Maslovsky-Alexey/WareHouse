using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Context;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;

namespace WareHouse.Data.EF.Repository
{
    public class WarehouseItemRepository : BaseRepository<Model.WarehouseItem>, IWarehouseItemRepository
    {
        public WarehouseItemRepository(WareHouseDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<WarehouseItem>> GetItemsByName(string name, bool ignoreCase)
        {
            if (ignoreCase)
            {
                return await context.WarehouseItem.Where(x => x.Item.Name.ToLower() == name.ToLower()).ToArrayAsync();
            }
            else
            {
                return await context.WarehouseItem.Where(x => x.Item.Name == name).ToArrayAsync();
            }
        }
    }
}
