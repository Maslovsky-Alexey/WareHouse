using System;
using Microsoft.EntityFrameworkCore;
using WareHouse.Data.Repository;
using WareHouse.Data.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using WareHouse.Data.EF.Context;

namespace WareHouse.Data.EF.Repository
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(WareHouseDbContext context) : base(context, context.Items)
        {

        }

        public async Task<Item> GetItemByName(string name)
        {
            return await context.Items.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Item> GetItemByNameIgnoreCase(string name)
        {
            return await context.Items.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
