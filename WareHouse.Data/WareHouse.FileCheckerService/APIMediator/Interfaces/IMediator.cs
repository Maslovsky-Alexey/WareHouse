using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.FileCheckerService.APIMediator.Interfaces
{
    public interface IMediator<T>
        where T : class
    {
        void AddItem(T item);
    }
}
