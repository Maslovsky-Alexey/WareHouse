using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.AutharizationAPI.SocialNetworks.UriExtension
{
    public static class UriExtension
    {
        public static void AddGetParameter(this UriBuilder sender, string key, string value)
        {
            var query = ParseQueryString(sender.Query);
            query.Add(new KeyValue(key, value));

            sender.Query = GetQueryString(query.ToArray());
        }

        private static List<KeyValue> ParseQueryString(string query)
        {
            var result = new List<KeyValue>();

            if (query.Length > 0)
                query = query.Substring(1);

            foreach (var s in query.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var key = s.Substring(0, s.IndexOf('='));
                var value = s.Substring(s.IndexOf('=') + 1);

                result.Add(new KeyValue(key, value));
            }

            return result;
        }

        private static string GetQueryString(KeyValue[] keyvalues)
        {
            var result = "?";

            for (int i = 0; i < keyvalues.Length; i++)
            {
                result += $"{keyvalues[i].Key}={keyvalues[i].Value}" + (i == keyvalues.Length - 1 ? "" : "&");
            }

            return result;
        }
    }
}
