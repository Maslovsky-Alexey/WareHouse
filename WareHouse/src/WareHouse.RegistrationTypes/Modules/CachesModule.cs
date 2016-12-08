using Autofac;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Caches;
using WareHouse.Data.EF.Context;

namespace WareHouse.RegistrationTypes.Modules
{
    public class CachesModule : Module
    {
        public CachesModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register(c => CacheManager.Instance)
                .As<ICacheManager>()
                .SingleInstance();

            RegisterRedis(builder, 1, "Items", null);
            RegisterRedis(builder, 2, "Orders", null);
            RegisterRedis(builder, 3, "Supplies", null);
            RegisterRedis(builder, 4, "PollingEventManager", new TimeSpan(1, 0, 0));
        }

        private void RegisterRedis(ContainerBuilder containerBuilder, int dbIndex, string key, TimeSpan? ttl)
        {
            var redisURL = "localhost:6379";

            containerBuilder.RegisterType<RedisCache>()
                .WithParameter("url", redisURL)
                .WithParameter("dbIndex", dbIndex)
                .WithParameter("ttl", ttl)
                .Keyed<ICache>(key);
        }
    }
}
