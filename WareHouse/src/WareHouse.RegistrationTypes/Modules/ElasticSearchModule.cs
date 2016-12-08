using Autofac;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Caches;
using WareHouse.Data.EF.Context;
using WareHouse.Domain.Service.ElasticSearchProviders;
using WareHouse.LogHelper;
using WareHouse.PollingEventManager;

namespace WareHouse.RegistrationTypes.Modules
{
    public class ElasticSearchModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<ElasticSearchProvider>()
                .As<IElasticSearchtemProvider>();
        }
    }
}
