using Autofac;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.AuthAPIHelper;
using WareHouse.Caches;
using WareHouse.Data.EF.Context;
using WareHouse.HttpWebHelperLibrary;
using WareHouse.LogHelper;
using WareHouse.PollingEventManager;

namespace WareHouse.RegistrationTypes.Modules
{
    public class HelpersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthHelper>()
                .As<IAuthHelper>()
                .WithParameter("autharizationApiUrl", "http://localhost:11492");

            builder
                .RegisterType<WebRequestHelper>()
                .As<IWebRequestHelper>();
        }
    }
}
