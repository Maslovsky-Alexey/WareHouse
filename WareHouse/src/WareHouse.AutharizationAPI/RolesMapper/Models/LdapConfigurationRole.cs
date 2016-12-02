using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.AutharizationAPI.RolesMapper.Models
{
    public class LdapConfigurationRole
    {
        public string ADRole { get; set; }

        public string WebRole { get; set; }
    }
}
