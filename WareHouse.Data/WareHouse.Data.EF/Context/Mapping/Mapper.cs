using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace WareHouse.Data.EF.Context.Mapping
{
    public static class Mapper
    {
        private static IEnumerable<Type> GetTypes(Type instanceType)
        {
            var assembly = instanceType.GetTypeInfo().Assembly;

            return assembly.GetTypes()
                .Where(type => type.GetTypeInfo().GetInterface(typeof(IMapper<>).Name) != null);
        }

        public static void MapModels(ModelBuilder modelBuilder)
        {
            var types = GetTypes(typeof(IMapper<>));

            foreach (Type type in types)
            {
                var genericType = type.GetTypeInfo().GetInterface(typeof(IMapper<>).Name).GetGenericArguments()[0];
                var method = modelBuilder.GetType().GetMethod("Entity", new Type[] { }).MakeGenericMethod(genericType);

                type.GetMethod("Map").Invoke(Activator.CreateInstance(type), new[] {
                    method.Invoke(modelBuilder, null)
                });
            }
        }
    }
}
