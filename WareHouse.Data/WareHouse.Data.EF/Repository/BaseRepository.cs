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
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        protected WareHouseDbContext context;
        protected DbSet<T> table;

        public BaseRepository(WareHouseDbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToArrayAsync();
        }

        public async Task<OperationStatus> Add(T item)
        {
            var count = 0;

            await Task.Factory.StartNew(() => table.Add(item));

            try
            {
                count = await SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + '\n' + e.InnerException); //TODO: Консоль - слишком частная привязка, для этого нужно использовать объект логгирования, который уже будет знать, куда это записать.
                return OperationStatus.Error;
            }


            return count > 0 ? OperationStatus.Added : OperationStatus.NotAdded;
        }

        public async Task<OperationStatus> Remove(T item)
        {
            await Task.Factory.StartNew(() => table.Remove(item));

            try
            {
                await SaveChanges();
            }
            catch
            {
                return OperationStatus.Error;
            }

            return OperationStatus.Removed;
        }

        public async Task<T> GetItem(int id)
        {
            return await table.FirstAsync(item => item.Id == id);
        }

        public async Task<int> Count()
        {
            return await table.CountAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllWithFilter(Expression<Func<T, bool>> filter)
        {
            return await Task<IEnumerable<T>>.Factory.StartNew(() => table.Where(filter));
        }

        public IEnumerable<T> GetAllSync()
        {
            return table.ToArray();
        }

        protected async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }
    }
}