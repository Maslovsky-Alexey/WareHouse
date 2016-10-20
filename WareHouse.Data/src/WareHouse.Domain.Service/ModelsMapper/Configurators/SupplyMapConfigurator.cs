using AutoMapper;
using WareHouse.Domain.Model;
using ItemStatus = WareHouse.Data.Model.ItemStatus;

namespace WareHouse.Domain.Service.ModelsMapper.Configurators
{
    public class SupplyMapConfigurator : IMapConfigurator
    {
        public IMapper ConfigurateEF()
        {
            return new MapperConfiguration(cfg => cfg
                    .CreateMap<Supply, Data.Model.Supply>()
                    .ForMember(obj => obj.Item,
                        obj =>
                            obj.ResolveUsing(
                                src =>
                                    new ModelsMapper<Data.Model.Item, Item>(new ItemMapConfigurator()).MapEF(
                                        src.Item)))
                    .ForMember(obj => obj.Provider,
                        obj =>
                            obj.ResolveUsing(
                                src =>
                                    new ModelsMapper<Data.Model.Provider, Provider>(new ProviderMapConfigurator())
                                        .MapEF(src.Provider)))
                    .ForMember(obj => obj.Employee,
                        obj =>
                            obj.ResolveUsing(
                                src =>
                                    new ModelsMapper<Data.Model.Employee, Employee>(new EmployeeMapConfigurator())
                                        .MapEF(src.Employee)))
                    .ForMember(obj => obj.Status,
                        obj =>
                            obj.ResolveUsing(
                                src =>
                                    new ModelsMapper<ItemStatus, Model.ItemStatus>(new EmployeeMapConfigurator())
                                        .MapEF(src.Status)))
            ).CreateMapper();
        }

        public IMapper ConfigurateService()
        {
            return new MapperConfiguration(cfg => cfg
                    .CreateMap<Data.Model.Supply, Supply>()
                    .ForMember(obj => obj.Provider,
                        obj =>
                            obj.ResolveUsing(
                                src =>
                                    new ModelsMapper<Data.Model.Provider, Provider>(new ProviderMapConfigurator())
                                        .MapService(src.Provider)))
                    .ForMember(obj => obj.Item,
                        obj =>
                            obj.ResolveUsing(
                                src =>
                                    new ModelsMapper<Data.Model.Item, Item>(new ItemMapConfigurator()).MapService(
                                        src.Item)))
                    .ForMember(obj => obj.Employee,
                        obj =>
                            obj.ResolveUsing(
                                src =>
                                    new ModelsMapper<Data.Model.Employee, Employee>(new ItemMapConfigurator())
                                        .MapService(src.Employee)))
                    .ForMember(obj => obj.Status,
                        obj =>
                            obj.ResolveUsing(
                                src =>
                                    new ModelsMapper<ItemStatus, Model.ItemStatus>(new ItemMapConfigurator())
                                        .MapService(src.Status)))
            ).CreateMapper();
        }
    }
}