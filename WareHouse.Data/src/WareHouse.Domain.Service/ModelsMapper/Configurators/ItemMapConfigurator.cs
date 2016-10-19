using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace WareHouse.Domain.Service.ModelsMapper.Configurators
{
    public class ItemMapConfigurator : IMapConfigurator
    {
        public IMapper ConfigurateEF()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Domain.Model.Item, Data.Model.Item>()
            ).CreateMapper();
        }

        public IMapper ConfigurateService()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Data.Model.Item, Domain.Model.Item>()
            ).CreateMapper();
        }
    }
}
