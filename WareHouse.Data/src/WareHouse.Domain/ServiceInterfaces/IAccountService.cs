using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model.ViewModel;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IAccountService
    {
        Task<bool> Login(LoginModel model);

        Task<UserModel> RegisterClient(RegisterModel model);

        Task<UserModel> RegisterEmployee(RegisterModel model);

        Task<UserModel> GetCurrentUser(HttpContext httpContext);
    }
}
