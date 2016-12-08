using Autofac;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Caches;
using WareHouse.Data.EF.Context;
using WareHouse.LogHelper;
using WareHouse.PollingEventManager;

namespace WareHouse.RegistrationTypes.Modules
{
    public class LogsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register(c => FileLog<WareHouse.Domain.Model.ViewModel.SignInLogModel>.Instance("d:\\log.txt"))
                .Keyed<ILog>("SignIn")
                .SingleInstance()
                .OnActivated(h => MyEventStream.MyEventStream.Instance.Subscribe(h.Instance));

            builder
                .RegisterType<ConsoleLog>()
                .As<ILog>();
        }
    }
}
