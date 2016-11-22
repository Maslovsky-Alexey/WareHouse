using System;

namespace WareHouse.Domain.Model
{
    public class Order : BaseModel
    {
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }


        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }


        public int ClientId { get; set; }

        public virtual Client Client { get; set; }


        public int StatusId { get; set; }

        public virtual ItemStatus Status { get; set; }


        public int Count { get; set; }

        public DateTime DateTime { get; set; }
    }
}