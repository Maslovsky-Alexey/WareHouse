using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouse.Data.Model.AnswerModel;

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

        Task<OperationStatusModel> Add(T item);

        Task<OperationStatus> Remove(T item);

        Task<T> GetItem(int id);

        Task<int> Count();
    }
}