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
    class ItemsCsvFileWatcher : RuntimeCsvFileWatcher<ItemCsvModel, ItemAPIModel>
    {
        public ItemsCsvFileWatcher(string folder, IChangeRepository changeRepository, IMediator<ItemAPIModel> mediator) : base(folder, changeRepository, mediator, 
            new Mapper.ModelsMapper<ItemCsvModel, ItemAPIModel>(new Mapper.Configurations.ItemsConfiguration()))
        {
            
        }
    }
}
