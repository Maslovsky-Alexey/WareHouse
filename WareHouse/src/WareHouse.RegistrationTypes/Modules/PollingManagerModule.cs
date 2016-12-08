using Autofac;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Caches;
using WareHouse.Data.EF.Context;
using WareHouse.PollingEventManager;

namespace WareHouse.RegistrationTypes.Modules
{
    public class PollingManagerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register(
                    context => PollingEventManager.PollingEventManager.Instance(context.ResolveKeyed<ICache>("PollingEventManager")))
                .As<IPollingEventManager>();
        }
    }
}
