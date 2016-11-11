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
using WareHouse.Domain.Service.HttpHelper;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using WareHouse.Domain.Model.AutharizationAPIModel;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Net;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class AccountService : IAccountService
    {
        private readonly ISafeClientService safeClientService;
        private readonly IUnsafeClientService unsafeClientService;

        private readonly ISafeEmployeeService safeEmployeeService;
        private readonly IUnsafeEmployeeService unsafeEmployeeService;
        private readonly string autharizationApiUrl;

        public AccountService(
            string autharizationApiUrl,
            ISafeClientService safeClientService, IUnsafeClientService unsafeClientService,
            ISafeEmployeeService safeEmployeeService, IUnsafeEmployeeService unsafeEmployeeService)
        {
            this.safeClientService = safeClientService;
            this.unsafeClientService = unsafeClientService;

            this.safeEmployeeService = safeEmployeeService;
            this.unsafeEmployeeService = unsafeEmployeeService;

            this.autharizationApiUrl = autharizationApiUrl;
        }

        public async Task<UserModel> GetCurrentUser(HttpContext httpContext)
        {
            var response = await new WebRequestHelper().SendRequest($"{autharizationApiUrl}/api/account?name={httpContext.User.Identity.Name}", "get", "");

            UserAPIModel apiUser = new WebRequestHelper().GetObjectFromResponse<UserAPIModel>(response);

            if (apiUser == null)
                return null;

            return await MapToUserModel(apiUser);
        }

        public async Task<string> Login(LoginModel model)
        {
            var response = await new WebRequestHelper().SendRequest($"{autharizationApiUrl}/api/account/login", "post", ToJson(model));

            UserAPIModel apiUser = new WebRequestHelper().GetObjectFromResponse<UserAPIModel>(response);

            if (apiUser == null)
                return null;

            return !string.IsNullOrEmpty(response.Headers["Authorization"]) ? response.Headers["Authorization"] : null;
        }

        public async Task<UserModel> RegisterClient(RegisterModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> RegisterEmployee(RegisterModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> GetUserByName(string username)
        {
            var response = await new WebRequestHelper().SendRequest($"{autharizationApiUrl}/api/account?name={username}", "get", "");
            UserAPIModel apiUser = new WebRequestHelper().GetObjectFromResponse<UserAPIModel>(response);

            return await MapToUserModel(apiUser);
        }

        public async Task<UserModel> GetUserByToken(string token)
        {
            var response = await new WebRequestHelper().SendRequest($"{autharizationApiUrl}/api/account?token={token}", "get", "");
            UserAPIModel apiUser = new WebRequestHelper().GetObjectFromResponse<UserAPIModel>(response);

            return await MapToUserModel(apiUser);
        }

        public async Task<IEnumerable<string>> GetUserRoles(string name)
        {
            var response = await new WebRequestHelper().SendRequest($"{autharizationApiUrl}/api/account?name={name}", "get", "");
            UserAPIModel apiUser = new WebRequestHelper().GetObjectFromResponse<UserAPIModel>(response);

            return apiUser.Roles;
        }

        private async Task<UserAPIModel> RegisterUserWithRole(RegisterModel model, string role)
        {
            var response = await new WebRequestHelper().SendRequest($"{autharizationApiUrl}/api/account/register", "post", ToJson(MapToRegisterModelAPI(model, role)));
            UserAPIModel apiUser = new WebRequestHelper().GetObjectFromResponse<UserAPIModel>(response);

            if (apiUser == null)
                return null;

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
                return (await safeEmployeeService.GetEmployeeByIdentityId(id)).Name;
            if (roles.Contains("client"))
                return (await safeClientService.GetClientByIdentityId(id)).Name;

            return null;
        }

        private async Task<UserModel> MapToUserModel(UserAPIModel apiUser)
        {
            return new UserModel
            {
                isEmployee = apiUser.Roles.Contains("employee"),
                Login = apiUser.UserName,
                Name = await GetUserName(apiUser.Id, apiUser.Roles)
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
            var response = await new WebRequestHelper().SendRequest($"{autharizationApiUrl}/api/account/{username}/roles/?role={role}", "post", null);

            UserAPIModel apiUser = new WebRequestHelper().GetObjectFromResponse<UserAPIModel>(response);

            if (role == "employee")
            {
                await unsafeEmployeeService.AddOrAssignWithApplicationUser(username, apiUser.Id);
            }
            else if (role == "client")
            {
                await unsafeClientService.AddOrAssignWithApplicationUser(username, apiUser.Id);
            }
            
            return await MapToUserModel(apiUser);
        }
    }
}