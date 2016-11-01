using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.FileCheckerService.APIMediator.Interfaces;
using WareHouse.FileCheckerService.Models.APIModel;
using WareHouse.FileCheckerService.Models.CsvModels;
using WareHouse.FileCheckerService.Repositories.Interfaces;

namespace WareHouse.FileCheckerService.FileWatcher
{
    public class OrdersCsvFileWatcher : RuntimeCsvFileWatcher<OrderCsvModel, OrderAPIModel>
    {
        public OrdersCsvFileWatcher(string folder, IChangeRepository changeRepository, IMediator<OrderAPIModel> mediator) : base(folder, changeRepository, mediator,
             new Mapper.ModelsMapper<OrderCsvModel, OrderAPIModel>(new Mapper.Configurations.OrdersConfiguration()))
        {
        }
    }
}
