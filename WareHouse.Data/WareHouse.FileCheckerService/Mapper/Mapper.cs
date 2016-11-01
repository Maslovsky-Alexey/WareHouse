using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.FileCheckerService.Mapper.Configurations;

namespace WareHouse.FileCheckerService.Mapper
{
    public class ModelsMapper<TSourceModel, TTargetModel>
    {
        private readonly IMapConfigurator configurator;

        public ModelsMapper(IMapConfigurator configurator)
        {
            this.configurator = configurator;
        }

        public TTargetModel MapService(TSourceModel source)
        {
            return configurator.ConfigurateSource().Map<TTargetModel>(source);
        }

        public TSourceModel MapEF(TTargetModel source)
        {
            return configurator.ConfigurateTarget().Map<TSourceModel>(source);
        }
    }
}
