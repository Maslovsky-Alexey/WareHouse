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
    public class ItemRepository : IItemRepository
    {
        private WareHouseDbContext context;

        public ItemRepository(WareHouseDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            return await context.Items.ToArrayAsync();
        }

        public async Task Add(Item client)
        {
            await Task.Factory.StartNew(() => context.Items.Add(client));
        }

        public async Task Remove(Item client)
        {
            await Task.Factory.StartNew(() => context.Items.Remove(client));
        }

        public async Task<Item> GetItem(int id)
        {
            return await context.Items.FirstAsync(item => item.ID == id);
        }

        public async Task<int> Count()
        {
            return await Task.Factory.StartNew(context.Items.Count);
        }
    }
}
