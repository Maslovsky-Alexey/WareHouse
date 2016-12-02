using System.Collections.Generic;
using System.Threading.Tasks;

namespace WareHouse.Data.Repository
{
    public enum OperationStatus
    {
        Added,
        NotAdded,
        Removed,
        NotRemoved,
        Error
    }

    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<OperationStatus> Add(T item);

        Task<OperationStatus> Remove(T item);

        Task<T> GetItem(int id);

        Task<int> Count();
    }
}