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
    public class OrdersConfiguration : IMapConfigurator
    {
        public IMapper ConfigurateSource()
        {
            return new MapperConfiguration(cfg => cfg
                .CreateMap<OrderCsvModel, OrderAPIModel>()
                .ForMember((OrderAPIModel csv) => csv.Item, opt => opt.MapFrom(x => new BaseModel { Id = x.ItemId }))
                .ForMember((OrderAPIModel csv) => csv.Client, opt => opt.MapFrom(x => new BaseModel { Id = x.ClientId }))
                .ForMember((OrderAPIModel csv) => csv.Employee, opt => opt.MapFrom(x => new BaseModel { Id = x.EmployeeId }))

            ).CreateMapper();
        }

        public IMapper ConfigurateTarget()
        {
            return new MapperConfiguration(cfg => cfg
                .CreateMap<OrderAPIModel, OrderCsvModel>()
                .ForMember((OrderCsvModel csv) => csv.ItemId, opt => opt.MapFrom(x => x.Item.Id))
                .ForMember((OrderCsvModel csv) => csv.ClientId, opt => opt.MapFrom(x => x.Client.Id))
                .ForMember((OrderCsvModel csv) => csv.EmployeeId, opt => opt.MapFrom(x => x.Employee.Id))

            ).CreateMapper();

        }
    }
}
