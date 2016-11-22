using AutoMapper;
using WareHouse.Domain.Model;

namespace WareHouse.Domain.Service.ModelsMapper.Configurators
{
    public class WarehouseItemMapConfigurator : IMapConfigurator
    {
        public IMapper ConfigurateEF()
        {
            return new MapperConfiguration(cfg => cfg
                    .CreateMap<WarehouseItem, Data.Model.WarehouseItem>()
                    .ForMember(obj => obj.Item,
                        obj =>
                            obj.ResolveUsing(
                                src =>
                                    new ModelsMapper<Data.Model.Item, Item>(new ItemMapConfigurator()).MapEF(
                                        src.Item)))
            ).CreateMapper();
        }

        public IMapper ConfigurateService()
        {
            return new MapperConfiguration(cfg => cfg
                    .CreateMap<Data.Model.WarehouseItem, WarehouseItem>()
                    .ForMember(obj => obj.Item,
                        obj =>
                            obj.ResolveUsing(
                                src =>
                                    new ModelsMapper<Data.Model.Item, Item>(new ItemMapConfigurator()).MapService(
                                        src.Item)))
            ).CreateMapper();
        }
    }
}