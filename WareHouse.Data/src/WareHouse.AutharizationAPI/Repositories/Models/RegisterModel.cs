using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.AutharizationAPI.Repositories.Models
{
    public class RegisterModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
