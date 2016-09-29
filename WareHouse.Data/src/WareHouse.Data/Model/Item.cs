using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Data.Model
{
    public class Item : BaseModel
    {
        public string Name { get; set; }
        
        public int Count { get; set; }

        public WarehouseItem WarehouseItem { get; set; }
    }
}
