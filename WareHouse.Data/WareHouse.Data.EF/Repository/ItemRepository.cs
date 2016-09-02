using System;
using Microsoft.EntityFrameworkCore;
using WareHouse.Data.Repository;
using WareHouse.Data.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WareHouse.Data.EF.Repository
{
    public class ItemRepository : IItemRepository
    {
        private DbSet<Item> items;

        public ItemRepository(DbContext context)
        {
            items = context.Set<Item>();
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            return await items.ToArrayAsync();
        }

        public async Task Add(Item client)
        {
            await Task.Factory.StartNew(() => items.Add(client));
        }

        public async Task Remove(Item client)
        {
            await Task.Factory.StartNew(() => items.Remove(client));
        }

        public async Task<Item> GetItem(int id)
        {
            return await items.FirstAsync(item => item.ID == id);
        }
    }
}
