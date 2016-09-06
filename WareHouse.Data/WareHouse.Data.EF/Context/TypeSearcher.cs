using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;

namespace WareHouse.Data.EF.Context
{
    public static class TypeSearcher
    {
        public static IEnumerable<Type> GetTypes(Type instanceType)
        {
            var assembly = instanceType.GetTypeInfo().Assembly;

            return assembly.GetTypes()
                .SelectMany(type => type.GetInterfaces())
                .Where(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == instanceType);
        }

        public static CallMethodWithParameters()
        {

        }
    }
}
