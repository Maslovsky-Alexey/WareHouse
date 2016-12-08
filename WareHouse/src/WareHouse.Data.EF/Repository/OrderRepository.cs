using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WareHouse.Data.EF.Context;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;

namespace WareHouse.Data.EF.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(WareHouseDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Order>> GetAll()
        {
            return await table
                .Include(x => x.Item)
                .Include(x => x.Status)
                .Include(x => x.Client)
                .Include(x => x.Employee)
                .ToListAsync();
        }

        public override async Task<Order> GetItem(int id)
        {
            return await table
            .Include(x => x.Item)
            .Include(x => x.Status)
            .Include(x => x.Client)
            .Include(x => x.Employee)
            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateOrderStatus(int id, int statusId)
        {
            var order = await GetItem(id);

            order.StatusId = statusId;

            await SaveChanges();
        }
    }
}