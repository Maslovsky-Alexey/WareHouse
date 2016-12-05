using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WareHouse.Data.EF.Context;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;

namespace WareHouse.Data.EF.Repository
{
    public class WarehouseItemRepository : BaseRepository<WarehouseItem>, IWarehouseItemRepository
    {
        public WarehouseItemRepository(WareHouseDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<WarehouseItem> GetItemByName(string name, bool ignoreCase)
        {
            if (ignoreCase)
                return await context.WarehouseItem.FirstOrDefaultAsync(x => x.Item.Name.ToLower() == name.ToLower());

            return await context.WarehouseItem.FirstOrDefaultAsync(x => x.Item.Name == name);
        }

        public override async Task<IEnumerable<WarehouseItem>> GetAll()
        {
            return await context.WarehouseItem
                .Include(x => x.Item)
                .ToListAsync();
        }

        public async Task<bool> UpdateCount(int warehouseItemId, int deltaCount)
        {
            var item = await GetItem(warehouseItemId);

            if (item == null)
                return false;

            item.Count += deltaCount;

            return (await SaveChanges()) > 0;
        }

        public override async Task<WarehouseItem> GetItem(int id)
        {
            return await table.Include(x => x.Item).FirstOrDefaultAsync(item => item.Id == id);
        }
    }
}