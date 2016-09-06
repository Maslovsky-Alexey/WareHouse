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
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        private WareHouseDbContext context;

        public ItemRepository(WareHouseDbContext context) : base(context.Items)
        {
            this.context = context;
        }        
    }
}
