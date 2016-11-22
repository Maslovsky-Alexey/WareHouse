using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.FileCheckerService.Context;
using WareHouse.FileCheckerService.Models;
using WareHouse.FileCheckerService.Repositories.Interfaces;

namespace WareHouse.FileCheckerService.Repositories
{
    public class ChangeRepository : BaseRepository<ChangeModel>, IChangeRepository
    {
        public ChangeRepository(HistoryDbContext context) : base(context)
        {

        }

        public OperationStatus AddOrUpdate(ChangeModel changeModel)
        {
            var item = GetByFullPath(changeModel.FullPath);

            if (item == null)
                return Add(changeModel);

            item.LastChange = changeModel.LastChange;
            item.FullPath = changeModel.FullPath;

            return SaveChanges();
        }

        public ChangeModel GetByFullPath(string fullpath)
        {
            return table.FirstOrDefault(x => fullpath == x.FullPath);
        }

        public DateTime GetDateTimeLastChange()
        {
            if (table.Count() <= 0)
                return DateTime.MinValue;

            return table.Max(x => x.LastChange);
        }

        public OperationStatus RemoveByFullPath(string fullpath)
        {
            var item = GetByFullPath(fullpath);

            if (item == null)
                return OperationStatus.Silence;

            return Remove(item);
        }
    }
}
