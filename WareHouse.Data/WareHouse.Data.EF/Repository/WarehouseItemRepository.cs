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

        public async Task<IEnumerable<WarehouseItem>> GetItemsByName(string name, bool ignoreCase)
        {
            if (ignoreCase)
                return await context.WarehouseItem.Where(x => x.Item.Name.ToLower() == name.ToLower()).ToArrayAsync();
            return await context.WarehouseItem.Where(x => x.Item.Name == name).ToArrayAsync();
        }

        public override async Task<IEnumerable<WarehouseItem>> GetAll()
        {
            return await context.WarehouseItem
                .Include(x => x.Item)
                .ToListAsync();
        }

        public override async Task<IEnumerable<WarehouseItem>> GetAllWithFilter(
            Expression<Func<WarehouseItem, bool>> filter)
        {
            return (await GetAll()).AsQueryable().Where(filter);
        }
    }
}