using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.AutharizationAPI.LdapHelper.Models
{
    public class LdapUser
    {
        public string UserName { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
