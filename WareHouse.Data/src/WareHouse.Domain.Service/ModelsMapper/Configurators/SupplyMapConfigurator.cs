using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq.Expressions;

namespace WareHouse.Domain.Service.ModelsMapper.Configurators
{
    public class SupplyMapConfigurator : IMapConfigurator
    {
        public IMapper ConfigurateEF()
        {
            return new MapperConfiguration(cfg => cfg
                .CreateMap<Domain.Model.Supply, Data.Model.Supply>()
                .ForMember((Data.Model.Supply obj) => obj.Item, 
                    obj => obj.ResolveUsing(src => new ModelsMapper<Data.Model.Item, Domain.Model.Item>(new ItemMapConfigurator()).MapEF(src.Item)))
                .ForMember((Data.Model.Supply obj) => obj.Provider,
                    obj => obj.ResolveUsing(src => new ModelsMapper<Data.Model.Provider, Domain.Model.Provider>(new ProviderMapConfigurator()).MapEF(src.Provider)))
                .ForMember((Data.Model.Supply obj) => obj.Employee,
                    obj => obj.ResolveUsing(src => new ModelsMapper<Data.Model.Employee, Domain.Model.Employee>(new EmployeeMapConfigurator()).MapEF(src.Employee)))
            ).CreateMapper();
        }

        public IMapper ConfigurateService()
        {
            return new MapperConfiguration(cfg => cfg
                .CreateMap<Data.Model.Supply, Domain.Model.Supply>()
                .ForMember((Domain.Model.Supply obj) => obj.Provider,
                    obj => obj.ResolveUsing(src => new ModelsMapper<Data.Model.Provider, Domain.Model.Provider>(new ProviderMapConfigurator()).MapService(src.Provider)))
                .ForMember((Domain.Model.Supply obj) => obj.Item,
                    obj => obj.ResolveUsing(src => new ModelsMapper<Data.Model.Item, Domain.Model.Item>(new ItemMapConfigurator()).MapService(src.Item)))
                .ForMember((Domain.Model.Supply obj) => obj.Employee,
                    obj => obj.ResolveUsing(src => new ModelsMapper<Data.Model.Employee, Domain.Model.Employee>(new ItemMapConfigurator()).MapService(src.Employee)))
            ).CreateMapper();
        }
    }
}
