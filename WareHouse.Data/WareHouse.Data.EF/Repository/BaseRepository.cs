using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;

namespace WareHouse.Data.EF.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        private DbSet<T> table;

        public BaseRepository(DbSet<T> table)
        {
            this.table = table;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToArrayAsync();           
        }

        public async Task Add(T item)
        {
            await Task.Factory.StartNew(() => table.Add(item));            
        }

        public async Task Remove(T item)
        {
            await Task.Factory.StartNew(() => table.Remove(item));
        }

        public async Task<T> GetItem(int id)
        {
            return await table.FirstAsync(item => item.ID == id);
        }

        public async Task<int> Count()
        {
            return await Task.Factory.StartNew(table.Count);
        }
    }
}
