using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WareHouse.FileCheckerService.Models.CsvModels;
using WareHouse.FileCheckerService.Models.APIModel;

namespace WareHouse.FileCheckerService.Mapper.Configurations
{
    public class ItemsConfiguration : IMapConfigurator
    {
        public IMapper ConfigurateSource()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<ItemCsvModel, ItemAPIModel>()).CreateMapper();
        }

        public IMapper ConfigurateTarget()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<ItemAPIModel, ItemCsvModel>()).CreateMapper();
        }
    }
}
