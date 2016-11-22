using AutoMapper;
using WareHouse.Domain.Model;
using ItemStatus = WareHouse.Data.Model.ItemStatus;

namespace WareHouse.Domain.Service.ModelsMapper.Configurators
{
    public class OrderMapConfigurator : IMapConfigurator
    {
        public IMapper ConfigurateEF()
        {
            return new MapperConfiguration(cfg => cfg
                    .CreateMap<Order, Data.Model.Order>()
                    .ForMember(obj => obj.Item,
                        obj =>
                            obj.ResolveUsing(
                                src =>
                                    new ModelsMapper<Data.Model.Item, Item>(new ItemMapConfigurator()).MapEF(
                                        src.Item)))
                    .ForMember(obj => obj.Client,
                        obj =>
                            obj.ResolveUsing(
                                src =>
                                    new ModelsMapper<Data.Model.Client, Client>(new ClientMapConfigurator()).MapEF(
                                        src.Client)))
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
                                    new ModelsMapper<ItemStatus, Model.ItemStatus>(new ItemStatusMapConfigurator())
                                        .MapEF(src.Status)))
            ).CreateMapper();
        }

        public IMapper ConfigurateService()
        {
            return new MapperConfiguration(cfg => cfg
                    .CreateMap<Data.Model.Order, Order>()
                    .ForMember(obj => obj.Client,
                        obj =>
                            obj.ResolveUsing(
                                src =>
                                    new ModelsMapper<Data.Model.Client, Client>(new ClientMapConfigurator())
                                        .MapService(src.Client)))
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
                                    new ModelsMapper<Data.Model.Employee, Employee>(new EmployeeMapConfigurator())
                                        .MapService(src.Employee)))
                    .ForMember(obj => obj.Status,
                        obj =>
                            obj.ResolveUsing(
                                src =>
                                    new ModelsMapper<ItemStatus, Model.ItemStatus>(new ItemStatusMapConfigurator())
                                        .MapService(src.Status)))
            ).CreateMapper();
        }
    }
}