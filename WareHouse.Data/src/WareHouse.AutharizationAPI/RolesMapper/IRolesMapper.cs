using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.AutharizationAPI.RolesMapper
{
    public interface IRolesMapper
    {
        IEnumerable<string> MapToWebRoles(IEnumerable<string> roles);
    }
}
