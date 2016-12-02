using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.FileCheckerService.Models.APIModel
{
    public class OrderAPIModel
    {
        public int Count { get; set; }

        public BaseModel Item { get; set; }

        public BaseModel Client { get; set; }

        public BaseModel Employee { get; set; }

    }
}
