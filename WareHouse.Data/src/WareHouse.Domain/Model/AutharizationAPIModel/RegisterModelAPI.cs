using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Domain.Model.AutharizationAPIModel
{
    public class RegisterModelAPI
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
