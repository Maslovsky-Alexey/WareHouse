using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace WareHouse.Domain.Service.ModelsMapper.Configurators
{
    public class EmployeeMapConfigurator : IMapConfigurator
    {
        public IMapper ConfigurateEF()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Domain.Model.Employee, Data.Model.Employee>()).CreateMapper();
        }

        public IMapper ConfigurateService()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Data.Model.Employee, Domain.Model.Employee>()).CreateMapper();
        }
    }
}
