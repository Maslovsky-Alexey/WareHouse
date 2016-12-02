using AutoMapper;
using WareHouse.Domain.Model;

namespace WareHouse.Domain.Service.ModelsMapper.Configurators
{
    public class ProviderMapConfigurator : IMapConfigurator
    {
        public IMapper ConfigurateEF()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Provider, Data.Model.Provider>()).CreateMapper();
        }

        public IMapper ConfigurateService()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Data.Model.Provider, Provider>()).CreateMapper();
        }
    }
}