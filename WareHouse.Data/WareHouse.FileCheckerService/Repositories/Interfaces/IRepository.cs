using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.FileCheckerService.Repositories.Interfaces
{
    public enum OperationStatus
    {
        Success,
        Error,
        Silence
    }

    public interface IRepository<T>
    {
        OperationStatus Add(T item);

        OperationStatus Remove(T item);

        T Get(int id);

        IEnumerable<T> GetAll();

        int Count();
    }
}
