using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Data.Model
{
    public enum Status
    {
        UnknowItem = 0,
        ProcessingSupply,
        ProcessingOrder,
        OrderFailed,
        SupplyFailed,
        OrederSuccess,
        SupplySuccess
    }

    public class ItemStatus : BaseModel
    {
        public string Name { get; set; }

        public WarehouseItem WarehouseItem { get; set; }

        public Status Status { get; set; }
    }
}
