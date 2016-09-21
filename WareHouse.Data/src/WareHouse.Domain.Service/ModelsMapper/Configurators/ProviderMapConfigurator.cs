using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace WareHouse.Domain.Service.ModelsMapper.Configurators
{
    public class ProviderMapConfigurator : IMapConfigurator
    {
        public IMapper ConfigurateEF()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Domain.Model.Provider, Data.Model.Provider>()).CreateMapper();
        }

        public IMapper ConfigurateService()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Data.Model.Provider, Domain.Model.Provider>()).CreateMapper();
        }
    }
}
