using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Context;
using WareHouse.Data.Repository;

namespace WareHouse.Data.EF.Repository
{
    public class WarehouseItemRepository : BaseRepository<Model.WarehouseItem>, IWarehouseItemRepository
    {
        public WarehouseItemRepository(WareHouseDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
