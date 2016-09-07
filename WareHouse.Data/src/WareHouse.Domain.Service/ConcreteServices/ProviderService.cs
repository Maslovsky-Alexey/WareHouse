using System;
using Microsoft.EntityFrameworkCore;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class ProviderRepository : BaseService<Provider>, IProviderService
    {

        public ProviderRepository(DbSet<Provider> providers) : base(providers)
        {
        }      
    }
}
