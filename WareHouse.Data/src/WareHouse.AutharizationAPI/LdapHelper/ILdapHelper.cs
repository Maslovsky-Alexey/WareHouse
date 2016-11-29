using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.AutharizationAPI.LdapHelper.Models;

namespace WareHouse.AutharizationAPI.LdapHelper
{
    public interface ILdapHelper
    {
        bool Connect(string host, int port);

        LdapUser Login(string username, string password);

        LdapUser GetUserByName(string username);

        void Disconnect();
    }
}
