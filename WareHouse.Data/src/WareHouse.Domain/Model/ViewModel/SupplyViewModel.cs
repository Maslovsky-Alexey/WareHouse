using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Domain.Model.ViewModel
{
    public class SupplyViewModel
    {
        public int ItemId { get; set; }

        public int Count { get; set; }

        public int StatusId { get; set; }

        public int ProviderId { get; set; }

        public int EmployeeId { get; set; }
    }
}
