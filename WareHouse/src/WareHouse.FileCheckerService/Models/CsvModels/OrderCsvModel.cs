using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.FileCheckerService.Models.CsvModels
{
    public class OrderCsvModel
    {
        public int Count { get; set; }

        public int ClientId { get; set; }

        public int ItemId { get; set; }

        public int EmployeeId { get; set; }
    }
}
