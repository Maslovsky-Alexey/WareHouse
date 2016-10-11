using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.MyOData
{
    // TODO: Реализовать через MobelBinder
    public class MyODataConfigurates
    {
        public IEnumerable<PropertyFilter> PropertiesFilter { get; set; }

        public string OrderBy { get; set; }

        public bool IsOrderAsceneding { get; set; } = true;
    }
}
