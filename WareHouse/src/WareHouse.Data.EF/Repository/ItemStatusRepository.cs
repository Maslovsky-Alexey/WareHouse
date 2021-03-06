﻿using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Context;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;

namespace WareHouse.Data.EF.Repository
{
    public class ItemStatusRepository : BaseRepository<ItemStatus>, IItemStatusRepository
    {
        public ItemStatusRepository(WareHouseDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<ItemStatus> GetStatus(Status status)
        {
            return await Task<ItemStatus>.Factory.StartNew(() => table.FirstOrDefault(x => x.Status == status));
        }
    }
}