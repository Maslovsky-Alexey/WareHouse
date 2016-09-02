using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Data.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        void Add(T item);

        void Remove(T item);
    }
}
