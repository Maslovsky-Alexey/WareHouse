using AutoMapper;

namespace WareHouse.Domain.Service.ModelsMapper.Configurators
{
    public interface IMapConfigurator
    {
        IMapper ConfigurateEF();

        IMapper ConfigurateService();
    }
}