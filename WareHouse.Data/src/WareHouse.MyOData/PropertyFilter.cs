using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.MyOData
{
    public class PropertyFilter
    {
        public string Name { get; set; }

        public string Filter { get; set; }

        public double? MoreThan { get; set; }

        public double? LessThan { get; set; }
    }
}
