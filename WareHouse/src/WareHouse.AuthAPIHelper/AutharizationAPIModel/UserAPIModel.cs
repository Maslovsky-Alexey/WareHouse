using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.AuthAPIHelper.AutharizationAPIModel
{
    public class UserAPIModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
