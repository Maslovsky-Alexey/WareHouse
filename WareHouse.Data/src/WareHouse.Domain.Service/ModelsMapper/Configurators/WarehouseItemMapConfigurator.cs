using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq.Expressions;

namespace WareHouse.Domain.Service.ModelsMapper.Configurators
{
    public class WarehouseItemMapConfigurator : IMapConfigurator
    {
        public IMapper ConfigurateEF()
        {
            return new MapperConfiguration(cfg => cfg
                .CreateMap<Domain.Model.WarehouseItem, Data.Model.WarehouseItem>()
                .ForMember((Data.Model.WarehouseItem obj) => obj.Status, 
                    obj => obj.ResolveUsing(src => new ModelsMapper<Data.Model.ItemStatus, Domain.Model.ItemStatus>(new ItemStatusMapConfigurator()).MapEF(src.Status)))
                .ForMember((Data.Model.WarehouseItem obj) => obj.Item,
                    obj => obj.ResolveUsing(src => new ModelsMapper<Data.Model.Item, Domain.Model.Item>(new ItemMapConfigurator()).MapEF(src.Item)))
            ).CreateMapper();
        }

        public IMapper ConfigurateService()
        {
            return new MapperConfiguration(cfg => cfg
                .CreateMap<Data.Model.WarehouseItem, Domain.Model.WarehouseItem>()
                .ForMember((Domain.Model.WarehouseItem obj) => obj.Status,
                    obj => obj.ResolveUsing(src => new ModelsMapper<Data.Model.ItemStatus, Domain.Model.ItemStatus>(new ItemStatusMapConfigurator()).MapService(src.Status)))
                .ForMember((Domain.Model.WarehouseItem obj) => obj.Item,
                    obj => obj.ResolveUsing(src => new ModelsMapper<Data.Model.Item, Domain.Model.Item>(new ItemMapConfigurator()).MapService(src.Item)))
            ).CreateMapper();
        }
    }
}
