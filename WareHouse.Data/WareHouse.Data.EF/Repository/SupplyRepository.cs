using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WareHouse.Data.EF.Context;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;

namespace WareHouse.Data.EF.Repository
{
    public class SupplyRepository : BaseRepository<Supply>, ISupplyRepository
    {
        public SupplyRepository(WareHouseDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Supply>> GetAll()
        {
            return await table
                .Include(x => x.Item)
                .Include(x => x.Status)
                .Include(x => x.Provider)
                .Include(x => x.Employee)
                .ToListAsync();
        }

        public async Task UpdateSupplyStatus(int id, int statusId)
        {
            var supply = await GetItem(id);

            supply.StatusId = statusId;

            await SaveChanges();
        }
    }
}