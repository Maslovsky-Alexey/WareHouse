using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WareHouse.Data.EF.Context;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;

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
                return await context.Providers.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            return await context.Providers.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}