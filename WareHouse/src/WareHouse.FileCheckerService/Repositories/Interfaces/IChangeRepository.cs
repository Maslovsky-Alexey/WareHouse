using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.FileCheckerService.Models;

namespace WareHouse.FileCheckerService.Repositories.Interfaces
{

    public interface IChangeRepository : IRepository<ChangeModel>
    {
        OperationStatus AddOrUpdate(ChangeModel changeModel);

        ChangeModel GetByFullPath(string fullpath);

        OperationStatus RemoveByFullPath(string fullpath);

        DateTime GetDateTimeLastChange();
    }
}
