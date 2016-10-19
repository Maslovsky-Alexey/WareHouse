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
        public ItemRepository(WareHouseDbContext context) : base(context)
        {

        }

        public async Task<Item> GetItemByName(string name, bool ignoreCase)
        {
            if (ignoreCase)
            {
                return await context.Items.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            }                
            else
            {
                return await context.Items.FirstOrDefaultAsync(x => x.Name == name);
            }            
        }

        public async Task<int> UpdateCount(int itemId, int deltaCount)
        {
            var item = await GetItem(itemId);
            item.Count += deltaCount;

            await SaveChanges();

            return item.Count;
        }
    }
}
