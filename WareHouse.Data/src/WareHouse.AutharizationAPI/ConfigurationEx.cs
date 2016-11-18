using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.AutharizationAPI
{
    public static class ConfigurationEx
    {
        public static T GetValue<T>(this IConfigurationRoot sender, params string[] path)
        {
            if (path == null || path.Length == 0)
            {
                throw new ArgumentException();
            }

            IConfigurationSection section = null;

            for (int i = 0; i < path.Length - 1; i++)
            {
                section = section != null ? section.GetSection(path[i]) : sender.GetSection(path[i]);
            }


            return section != null ? section.GetValue<T>(path.Last()) : sender.GetValue<T>(path.Last());
        }

        public static T GetValueFromJSON<T>(this IConfigurationRoot sender, params string[] path)
        {
            var value = sender.GetValue<string>(path);

            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
