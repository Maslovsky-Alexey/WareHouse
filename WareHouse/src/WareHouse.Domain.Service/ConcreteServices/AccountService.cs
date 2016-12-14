using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WareHouse.Data.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.ServiceInterfaces;
using Employee = WareHouse.Domain.Model.Employee;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.ServiceInterfaces.Unsafe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Net;
using WareHouse.HttpWebHelperLibrary;
using WareHouse.AuthAPIHelper;
using WareHouse.AuthAPIHelper.AutharizationAPIModel;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class AccountService : IAccountService
    {
        private readonly ISafeClientService safeClientService;
        private readonly IUnsafeClientService unsafeClientService;

        private readonly ISafeEmployeeService safeEmployeeService;
        private readonly IUnsafeEmployeeService unsafeEmployeeService;

        private readonly IAuthHelper authHelper;

        public AccountService(
            ISafeClientService safeClientService, IUnsafeClientService unsafeClientService,
            ISafeEmployeeService safeEmployeeService, IUnsafeEmployeeService unsafeEmployeeService,
            IAuthHelper authHelper)
        {
            this.safeClientService = safeClientService;
            this.unsafeClientService = unsafeClientService;

            this.safeEmployeeService = safeEmployeeService;
            this.unsafeEmployeeService = unsafeEmployeeService;

            this.authHelper = authHelper;
        }

        public async Task<UserModel> GetCurrentUser(HttpContext httpContext)
        {
            var apiUser = await authHelper.GetUserByName(httpContext.User.Identity.Name);

            if (apiUser == null)
                return null;

            return await MapToUserModel(apiUser);
        }

        public async Task<string> Login(LoginModel model)
        {
            var token = await authHelper.Login(new PasswordNameModel { Password = model.Password, Username = model.Username });

            return token;
        }

        public async Task<UserModel> GetUserByName(string username)
        {
            var apiUser = await authHelper.GetUserByName(username);
            return await MapToUserModel(apiUser);
        }

        public async Task<UserModel> GetUserByToken(string token)
        {
            var apiUser = await authHelper.GetUserByToken(token);

            return await MapToUserModel(apiUser);
        }

        public async Task<IEnumerable<string>> GetUserRoles(string name)
        {
            return await authHelper.GetUserRoles(name);
        }

        private async Task<UserAPIModel> RegisterUserWithRole(RegisterModel model, string role)
        {
            var apiUser = await authHelper.RegisterUserWithRole(model.Username, model.Password, role);

            return apiUser;
        }

        private RegisterModelAPI MapToRegisterModelAPI(RegisterModel model, params string[] roles)
        {
            return new RegisterModelAPI
            {
                Username = model.Username,
                Password = model.Password,
                Roles = roles
            };
        }

        private async Task<string> GetUserName(string id, IEnumerable<string> roles)
        {
            if (roles.Contains("employee"))
                return (await safeEmployeeService.GetEmployeeByIdentityId(id))?.Name;
            if (roles.Contains("client"))
                return (await safeClientService.GetClientByIdentityId(id))?.Name;

            return null;
        }

        private async Task<UserModel> MapToUserModel(UserAPIModel apiUser)
        {
            var name = await GetUserName(apiUser.Id, apiUser.Roles);        

            if (name == null)
            {
                foreach (var role in apiUser.Roles)
                {
                   await AddOrAssignWithApplicationUser(apiUser, role);
                }     
            }

            name = await GetUserName(apiUser.Id, apiUser.Roles);

            return new UserModel
            {
                isEmployee = apiUser.Roles.Contains("employee"),
                Login = apiUser.UserName,
                Name = name
            };
        }

        private string ToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

        public async Task<UserModel> AddRole(string username, string role)
        {
            var apiUser = await authHelper.AddRole(username, role);

            if (apiUser == null)
            {
                return null;
            }

            await AddOrAssignWithApplicationUser(apiUser, role);

            return await MapToUserModel(apiUser);
        }

        private async Task AddOrAssignWithApplicationUser(UserAPIModel apiUser, string role)
        {
            if (role == "employee")
            {
                await unsafeEmployeeService.AddOrAssignWithApplicationUser(apiUser.UserName, apiUser.Id);
            }
            else if (role == "client")
            {
                await unsafeClientService.AddOrAssignWithApplicationUser(apiUser.UserName, apiUser.Id);
            }
        }
    }
}