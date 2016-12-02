using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WareHouse.MyOData
{
    public static class ObjectHelper
    {
        public static object GetValueFromPublicProperyWithIgnoreCase(this object sender, string propertyName)
        {
            return sender
                    .GetType()
                    .GetTypeInfo()
                    .GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                    .GetValue(sender, null);
        }
    }
}
