using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.Model;
using WareHouse.Domain.Model.ViewModel;

namespace WareHouse.Domain.ServiceInterfaces.Safe
{
    public interface ISafeAccountService
    {
        Task<bool> Login(LoginModel model);

        Task<UserModel> GetCurrentUser(HttpContext httpContext);

        Task<UserModel> GetUserByName(string username);
    }
}
