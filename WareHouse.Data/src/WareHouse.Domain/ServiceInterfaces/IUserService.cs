using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.Model;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserByName(string name, bool ignoreCase);
    }
}
