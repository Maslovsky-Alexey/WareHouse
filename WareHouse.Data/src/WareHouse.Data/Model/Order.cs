using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Data.Model
{
    public class Order : BaseModel
    {
        public int ItemId { get; set; }

        public Item Item { get; set; }


        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }


        public int ClientId { get; set; }

        public Client Client { get; set; }


        public int Count { get; set; }

        public DateTime DateTime { get; set; }

    }
}
