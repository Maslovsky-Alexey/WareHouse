using AutoMapper;
using WareHouse.Domain.Model;

namespace WareHouse.Domain.Service.ModelsMapper.Configurators
{
    public class ItemMapConfigurator : IMapConfigurator
    {
        public IMapper ConfigurateEF()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Item, Data.Model.Item>()
            ).CreateMapper();
        }

        public IMapper ConfigurateService()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Data.Model.Item, Item>()
            ).CreateMapper();
        }
    }
}