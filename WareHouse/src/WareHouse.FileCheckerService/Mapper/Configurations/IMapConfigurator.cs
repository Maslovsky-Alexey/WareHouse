using AutoMapper;

namespace WareHouse.FileCheckerService.Mapper.Configurations
{
    public interface IMapConfigurator
    {
        IMapper ConfigurateSource();

        IMapper ConfigurateTarget();
    }
}