using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Domain.Service.ModelsMapper.Configurators
{
    public interface IMapConfigurator
    {
        IMapper ConfigurateEF();

        IMapper ConfigurateService();
    }
}
