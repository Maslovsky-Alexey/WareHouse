using System;

namespace WareHouse.Domain.Model.ViewModel
{
    public class SupplyViewModel
    {
        public int Id { get; set; }

        public Item Item { get; set; }

        public int Count { get; set; }

        public ItemStatus Status { get; set; }

        public Provider Provider { get; set; }

        public Employee Employee { get; set; }

        public string DateTime { get; set; }
    }
}