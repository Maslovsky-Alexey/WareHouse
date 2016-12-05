using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.MyOData.Concrete.Configurators
{
    public class WarehouseItemODataConfigurator
    {
        private MyODataConfigurates config;

        public WarehouseItemODataConfigurator(MyODataConfigurates config)
        {
            this.config = config;
        }
        
        public bool OrderByName
        {
            get
            {
                return config.OrderBy.ToLower() == "name";
            }
        }

        public bool OrderByCount
        {
            get
            {
                return config.OrderBy.ToLower() == "count";
            }
        }

        public PropertyFilter CountFilter
        {
            get
            {
                return config.PropertiesFilter.FirstOrDefault(x => x.Name == "count");
            }
        }

        public bool OrderDesc
        {
            get
            {
                return !config.IsOrderAsceneding;
            }
        }
    }
}
