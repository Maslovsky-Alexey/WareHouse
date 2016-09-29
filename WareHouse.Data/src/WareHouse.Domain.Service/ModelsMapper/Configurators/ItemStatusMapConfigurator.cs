using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace WareHouse.Domain.Service.ModelsMapper.Configurators
{
    public class ItemStatusMapConfigurator : IMapConfigurator
    {
        public IMapper ConfigurateEF()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Domain.Model.ItemStatus, Data.Model.ItemStatus>()
                .ForMember((Data.Model.ItemStatus obj) => obj.WarehouseItem,
                    obj => obj.Ignore())
            ).CreateMapper();
        }

        public IMapper ConfigurateService()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Data.Model.ItemStatus, Domain.Model.ItemStatus>()
                .ForMember((Domain.Model.ItemStatus obj) => obj.WarehouseItem,
                    obj => obj.Ignore())
            ).CreateMapper();
        }
    }
}
