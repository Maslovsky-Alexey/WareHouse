using AutoMapper;
using WareHouse.Domain.Model;

namespace WareHouse.Domain.Service.ModelsMapper.Configurators
{
    public class EmployeeMapConfigurator : IMapConfigurator
    {
        public IMapper ConfigurateEF()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Employee, Data.Model.Employee>()).CreateMapper();
        }

        public IMapper ConfigurateService()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Data.Model.Employee, Employee>()).CreateMapper();
        }
    }
}