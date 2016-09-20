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
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        protected DbSet<T> table;
        protected WareHouseDbContext context;

        //TODO: Получив весь DBContext можно получить из него отдельный DBSet, передавать его как парамерт излишне
        public BaseRepository(WareHouseDbContext context, DbSet<T> table)
        {
            this.table = table;
            this.context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToArrayAsync();           
        }

        public IEnumerable<T> GetAllSync()
        {
            return table.ToArray();
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

        public async Task SaveChanges()
        {
            //TODO: Почему не используешь асинхронный метод? (SaveChangesAsync)
            await Task.Factory.StartNew(() => context.SaveChanges());
        }
    }
}
