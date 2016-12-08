using Autofac;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Context;

namespace WareHouse.RegistrationTypes.Modules
{
    public class EFModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var options = new DbContextOptionsBuilder<WareHouseDbContext>().Options;

            builder
                .Register(context => { return new WareHouseDbContext(options); })
                .InstancePerDependency();
        }
    }
}
