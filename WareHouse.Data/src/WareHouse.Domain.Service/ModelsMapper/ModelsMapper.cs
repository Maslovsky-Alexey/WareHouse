using WareHouse.Domain.Service.ModelsMapper.Configurators;

namespace WareHouse.Domain.Service.ModelsMapper
{
    public class ModelsMapper<EFmodel, ServiceModel>
    {
        private readonly IMapConfigurator configurator;

        public ModelsMapper(IMapConfigurator configurator)
        {
            this.configurator = configurator;
        }

        public ServiceModel MapService(EFmodel source)
        {
            return configurator.ConfigurateService().Map<ServiceModel>(source);
        }

        public EFmodel MapEF(ServiceModel source)
        {
            return configurator.ConfigurateEF().Map<EFmodel>(source);
        }
    }
}