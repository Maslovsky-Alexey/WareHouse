using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.FileCheckerService
{
    public class ConfigurationManager
    {
        public ConfigurationManager()
        {

        }

        public string GetValue(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }
    }
}
