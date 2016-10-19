using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Domain.Model
{
    public class WarehouseItem : BaseModel
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int StatusId { get; set; }
        public virtual ItemStatus Status { get; set; }

        public int Count { get; set; }
    }
}
