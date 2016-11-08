using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WareHouse.Data.Model;
using WareHouse.Domain.Model.ViewModel;

namespace WareHouse.Domain.ServiceInterfaces.Safe
{
    public interface ISafeAccountService
    {
        Task<string> Login(LoginModel model);

        Task<UserModel> GetUserByName(string username);

        Task<IEnumerable<string>> GetUserRoles(string name);
        Task<UserModel> GetCurrentUser(HttpContext httpContext);
    }
}
