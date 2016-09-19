using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Reflection;

namespace WareHouse.MyOData
{
    public static class MyOData
    {
        public static MyODataConfigurates GetConfiguratesFromQueryString(string queryString)
        {
            var configurates = new MyODataConfigurates();

            configurates.PropertiesFilter = GetPropertiesFilter(queryString);

            var orders = MatchesBySelector("orderby", queryString);
            configurates.OrderBy = orders.Count > 0 ? orders[orders.Count - 1].Groups["value"].Value : "";

            var types = MatchesBySelector("ordertype", queryString);
            configurates.IsOrderAsceneding = types.Count > 0 ? types[types.Count - 1].Groups["value"].Value.ToLower() != "descending" : true;

            return configurates;
        }

        public static IEnumerable<T> ApplyMyODataCongigurates<T>(IEnumerable<T> items, MyODataConfigurates config)
        {
            foreach (PropertyFilter prop in config.PropertiesFilter)
                items = items.Where((item) => ((string)item.GetType().GetTypeInfo().GetProperty(prop.Name).GetValue(item)).IndexOf(prop.Filter) > -1);

            if (String.IsNullOrEmpty(config.OrderBy))
                return items;


            if (config.IsOrderAsceneding)
                items = items.OrderBy((item) => item.GetType().GetTypeInfo().GetProperty(config.OrderBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(item, null));
            else
                items = items.OrderByDescending((item) => item.GetType().GetTypeInfo().GetProperty(config.OrderBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(item, null));

            return items;
        }

        private static IEnumerable<PropertyFilter> GetPropertiesFilter(string source)
        {
            var result = new List<PropertyFilter>();

            var properties = GetElement("property", source);
            var filters = GetElement("filter", source);

            foreach (Element element in properties)
                result.Add(new PropertyFilter()
                {
                    Name = element.Value,
                    Filter = filters.FirstOrDefault((filter) => filter.ID == element.ID).Value
                });

            return result;
        }


        private static IEnumerable<Element> GetElement(string selector, string source)
        {
            var matches = MatchesBySelector(selector, source);
            var result = new List<Element>();

            foreach (Match match in matches)
                result.Add(new Element() {
                    ID = int.Parse(match.Groups["id"].Value),
                    Value = match.Groups["value"].Value
                });

            return result;
        }

        private static MatchCollection MatchesBySelector(string selector, string source)
        {
            var result = new List<string>();
            var pattern = $@"(\${WordPatternToAnyRegister(selector)}(?<id>\d*))=(?<value>.+?)(\&|$)";

            return Regex.Matches(source, pattern);
        }

        private static string WordPatternToAnyRegister(string word)
        {
            string result = "";

            foreach (char c in word)
                result += $"[{char.ToLower(c)}{char.ToUpper(c)}]";

            return result;
        }
    }
}
