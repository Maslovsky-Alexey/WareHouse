using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.FileCheckerService.Context;
using WareHouse.FileCheckerService.Models;
using WareHouse.FileCheckerService.Repositories.Interfaces;

namespace WareHouse.FileCheckerService.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T>
        where T : BaseModel
    {
        protected HistoryDbContext context;
        protected DbSet<T> table;


        public BaseRepository(HistoryDbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }

        public OperationStatus Add(T item)
        {
            table.Add(item);
            return SaveChanges();
        }

        public int Count()
        {
            return table.Count();
        }

        public T Get(int id)
        {
            return table.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToArray();
        }

        public OperationStatus Remove(T item)
        {
            table.Remove(item);

            return SaveChanges();
        }

        protected OperationStatus SaveChanges()
        {
            var countChanges = 0;

            try
            {
                countChanges = context.SaveChanges();
            }
            catch(Exception e)
            {
                return OperationStatus.Error;
            }

            return countChanges > 0 ? OperationStatus.Success : OperationStatus.Silence;
        }
    }
}
