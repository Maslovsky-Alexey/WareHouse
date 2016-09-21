using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace WareHouse.Domain.Service.ModelsMapper.Configurators
{
    public class ClientMapConfigurator : IMapConfigurator
    {
        public IMapper ConfigurateEF()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Domain.Model.Client, Data.Model.Client>()).CreateMapper();
        }

        public IMapper ConfigurateService()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Data.Model.Client, Domain.Model.Client>()).CreateMapper();
        }
    }
}
