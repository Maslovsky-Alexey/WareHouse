using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Domain.Model.ViewModel
{
    public class WarehouseItemViewModel
    {
        public string Name { get; set; }

        public int ItemId { get; set; }

        public int Count { get; set; }

        public string Status { get; set; }

        public int StatusId { get; set; }
    }
}
