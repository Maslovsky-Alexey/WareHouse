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
    public class ProviderRepository : IProviderRepository
    {
        private WareHouseDbContext context;

        public ProviderRepository(WareHouseDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Provider>> GetAll()
        {
            return await context.Providers.ToArrayAsync();
        }

        public async Task Add(Provider client)
        {
            await Task.Factory.StartNew(() => context.Providers.Add(client));
        }

        public async Task Remove(Provider client)
        {
            await Task.Factory.StartNew(() => context.Providers.Remove(client));
        }

        public async Task<Provider> GetItem(int id)
        {
            return await context.Providers.FirstAsync(provider => provider.ID == id);
        }

        public async Task<int> Count()
        {
            return await Task.Factory.StartNew(context.Providers.Count);
        }
    }
}
