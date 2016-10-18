using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq.Expressions;

namespace WareHouse.Domain.Service.ModelsMapper.Configurators
{
    public class OrderMapConfigurator : IMapConfigurator
    {
        public IMapper ConfigurateEF()
        {
            return new MapperConfiguration(cfg => cfg
                .CreateMap<Domain.Model.Order, Data.Model.Order>()
                .ForMember((Data.Model.Order obj) => obj.Item,
                    obj => obj.ResolveUsing(src => new ModelsMapper<Data.Model.Item, Domain.Model.Item>(new ItemMapConfigurator()).MapEF(src.Item)))
                .ForMember((Data.Model.Order obj) => obj.Client,
                    obj => obj.ResolveUsing(src => new ModelsMapper<Data.Model.Client, Domain.Model.Client>(new ClientMapConfigurator()).MapEF(src.Client)))
                .ForMember((Data.Model.Order obj) => obj.Employee,
                    obj => obj.ResolveUsing(src => new ModelsMapper<Data.Model.Employee, Domain.Model.Employee>(new EmployeeMapConfigurator()).MapEF(src.Employee)))
            ).CreateMapper();
        }

        public IMapper ConfigurateService()
        {
            return new MapperConfiguration(cfg => cfg
                .CreateMap<Data.Model.Order, Domain.Model.Order>()
                .ForMember((Domain.Model.Order obj) => obj.Client,
                    obj => obj.ResolveUsing(src => new ModelsMapper<Data.Model.Client, Domain.Model.Client>(new ClientMapConfigurator()).MapService(src.Client)))
                .ForMember((Domain.Model.Order obj) => obj.Item,
                    obj => obj.ResolveUsing(src => new ModelsMapper<Data.Model.Item, Domain.Model.Item>(new ItemMapConfigurator()).MapService(src.Item)))
                .ForMember((Domain.Model.Order obj) => obj.Employee,
                    obj => obj.ResolveUsing(src => new ModelsMapper<Data.Model.Employee, Domain.Model.Employee>(new ItemMapConfigurator()).MapService(src.Employee)))
            ).CreateMapper();
        }
    }
}
