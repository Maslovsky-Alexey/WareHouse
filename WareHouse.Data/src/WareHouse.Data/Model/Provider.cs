using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Data.Model
{
    public class Provider : BaseModel
    {
        public string Name { get; set; }

        public IEnumerable<Supply> Supplies { get; set; }
    }
}
