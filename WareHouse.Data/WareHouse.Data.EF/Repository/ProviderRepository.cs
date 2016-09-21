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
        public ProviderRepository(WareHouseDbContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<Provider> GetProviderByName(string name, bool ignoreCose)
        {
            if (ignoreCose)
            {
                return await context.Providers.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            }
            else
            {
                return await context.Providers.FirstOrDefaultAsync(x => x.Name == name);
            }
        }
    }
}
