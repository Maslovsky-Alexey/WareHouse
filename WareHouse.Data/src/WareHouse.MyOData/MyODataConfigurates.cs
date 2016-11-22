using System.Collections.Generic;

namespace WareHouse.MyOData
{
    public class MyODataConfigurates
    {
        public IEnumerable<PropertyFilter> PropertiesFilter { get; set; }

        public string OrderBy { get; set; }

        public bool IsOrderAsceneding { get; set; } = true;
    }
}