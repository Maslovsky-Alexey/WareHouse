using System;
using Microsoft.EntityFrameworkCore;
using WareHouse.Data.Repository;
using WareHouse.Data.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using WareHouse.Data.EF.Context;

namespace WareHouse.Data.EF.Repository
{
    public class ProviderRepository : BaseRepository<Provider>, IProviderRepository
    {
        private WareHouseDbContext context;

        public ProviderRepository(WareHouseDbContext context) : base(context.Providers)
        {
            this.context = context;
        }      
    }
}
