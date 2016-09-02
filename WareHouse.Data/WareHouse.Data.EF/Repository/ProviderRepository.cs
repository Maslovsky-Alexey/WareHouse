using System;
using Microsoft.EntityFrameworkCore;
using WareHouse.Data.Repository;
using WareHouse.Data.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WareHouse.Data.EF.Repository
{
    public class ProviderRepository : IProviderRepository
    {
        private DbSet<Provider> providers;

        public ProviderRepository(DbContext context)
        {
            providers = context.Set<Provider>();
        }

        public async Task<IEnumerable<Provider>> GetAll()
        {
            return await providers.ToArrayAsync();
        }

        public async Task Add(Provider client)
        {
            await Task.Factory.StartNew(() => providers.Add(client));
        }

        public async Task Remove(Provider client)
        {
            await Task.Factory.StartNew(() => providers.Remove(client));
        }

        public async Task<Provider> GetItem(int id)
        {
            return await providers.FirstAsync(provider => provider.ID == id);
        }

        public async Task<int> Count()
        {
            return await Task.Factory.StartNew(providers.Count);
        }
    }
}
