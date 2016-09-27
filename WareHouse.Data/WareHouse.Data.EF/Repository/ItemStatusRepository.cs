using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.Repository;
using WareHouse.Data.Model;
using WareHouse.Data.EF.Context;


namespace WareHouse.Data.EF.Repository
{
    public class ItemStatusRepository : BaseRepository<ItemStatus>, IItemStatusRepository
    {
        public ItemStatusRepository(WareHouseDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
