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

        public async Task UpdateOrderStatus(int id, int statusId)
        {
            var order = await GetItem(id);

            order.StatusId = statusId;

            await SaveChanges();
        }
    }
}
