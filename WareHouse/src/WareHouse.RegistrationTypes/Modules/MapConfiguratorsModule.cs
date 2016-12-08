using Autofac;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Caches;
using WareHouse.Data.EF.Context;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.PollingEventManager;

namespace WareHouse.RegistrationTypes.Modules
{
    public class MapConfiguratorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClientMapConfigurator>();
            builder.RegisterType<EmployeeMapConfigurator>();
            builder.RegisterType<ItemMapConfigurator>();
            builder.RegisterType<ItemStatusMapConfigurator>();
            builder.RegisterType<OrderMapConfigurator>();
            builder.RegisterType<SupplyMapConfigurator>();
            builder.RegisterType<WarehouseItemMapConfigurator>();
            builder.RegisterType<ProviderMapConfigurator>();
        }
    }
}
