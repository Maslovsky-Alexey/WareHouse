using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WareHouse.MyEventStream
{
    public static class ReflectionEx
    {
        public static bool IsInstanceOfType(this Type sender, object source)
        {
            return sender.GetTypeInfo().IsInstanceOfType(source);
        }

        public static Type GetInterfaceByPattern(this object sender, string pattern, bool ignoreCase)
        {
            var culture = ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture;

            return sender
                .GetType()
                .GetTypeInfo()
                .GetInterfaces()
                .FirstOrDefault(x => x.Name.IndexOf(pattern, culture) > -1);
        }
    }
}
