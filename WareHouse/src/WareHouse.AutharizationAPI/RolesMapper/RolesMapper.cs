using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.AutharizationAPI.RolesMapper.Models;

namespace WareHouse.AutharizationAPI.RolesMapper
{
    public class RolesMapper : IRolesMapper
    {
        private IEnumerable<LdapConfigurationRole> mapRules;

        public RolesMapper(IEnumerable<LdapConfigurationRole> mapRules)
        {
            this.mapRules = mapRules;
        }

        public IEnumerable<string> MapToWebRoles(IEnumerable<string> roles)
        {
            var result = new List<string>();

            foreach (var role in roles)
            {
                var rule = mapRules.FirstOrDefault(x => x.ADRole == role);

                if (rule != null)
                {
                    result.Add(rule.WebRole);
                }
            }

            return result;
        }
    }
}
