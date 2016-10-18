using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Data.Model
{
    public class Supply : BaseModel
    {
        public int ItemId { get; set; }

        public Item Item { get; set; }


        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }


        public int ProviderId { get; set; }

        public Provider Provider { get; set; }


        public int Count { get; set; }

        public DateTime DateTime { get; set; }
    }
}
