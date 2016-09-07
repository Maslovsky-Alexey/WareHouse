using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task Add(T item);

        Task Remove(T item);

        Task<T> GetItem(int id);

        Task<int> Count();
    }
}
