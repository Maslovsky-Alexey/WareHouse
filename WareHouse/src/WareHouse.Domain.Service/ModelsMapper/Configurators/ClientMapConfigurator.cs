using AutoMapper;
using WareHouse.Domain.Model;

namespace WareHouse.Domain.Service.ModelsMapper.Configurators
{
    public class ClientMapConfigurator : IMapConfigurator
    {
        public IMapper ConfigurateEF()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Client, Data.Model.Client>()).CreateMapper();
        }

        public IMapper ConfigurateService()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Data.Model.Client, Client>()).CreateMapper();
        }
    }
}