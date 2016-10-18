using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Data.Model
{
    public class Employee : BaseModel
    {
        public string Name { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public IEnumerable<Order> Orders { get; set; }

        public IEnumerable<Supply> Supplies { get; set; }
    }
}
