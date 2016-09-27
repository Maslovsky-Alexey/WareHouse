using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Data.Model
{
    public class WarehouseItem : BaseModel
    {
        public virtual Item Item { get; set; }

        public virtual ItemStatus Status { get; set; }

        public int Count { get; set; }
    }
}
