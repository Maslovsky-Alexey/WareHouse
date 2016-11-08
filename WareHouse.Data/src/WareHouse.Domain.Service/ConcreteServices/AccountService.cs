﻿using System.Linq;
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

            UserAPIModel apiUser = GetObjectFromResponse<UserAPIModel>(response);

            if (apiUser == null)
                return null;

            return await MapToUserModel(apiUser);
        }

        public async Task<string> Login(LoginModel model)
        {
            var response = await new WebRequestHelper().SendRequest($"{autharizationApiUrl}/api/account/login", "post", ToJson(model));

            UserAPIModel apiUser = GetObjectFromResponse<UserAPIModel>(response);

            if (apiUser == null)
                return null;

            return !string.IsNullOrEmpty(response.Headers["Authorization"]) ? response.Headers["Authorization"] : null;
        }

        public async Task<UserModel> RegisterClient(RegisterModel model)
        {
            var client = await safeClientService.GetClientByName(model.Username, true);

            if (client != null && !string.IsNullOrEmpty(client.UserId))
                return null;

            var user = await RegisterUserWithRole(model, "client");

            if (client == null)
                await unsafeClientService.Add(new Domain.Model.Client {Name = model.Username, UserId = user.Id});   
            else
                await unsafeClientService.AssignWithApplicationUser(client.Id, user.Id);
            
            return await MapToUserModel(user);
        }

        public async Task<UserModel> RegisterEmployee(RegisterModel model)
        {
            var employee = await safeEmployeeService.GetEmployeeByName(model.Username, true);

            if (employee != null && !string.IsNullOrEmpty(employee.UserId))
                return null;

            var user = await RegisterUserWithRole(model, "employee");

            if (employee == null)
                await unsafeEmployeeService.Add(new Domain.Model.Employee { Name = model.Username, UserId = user.Id });
            else
                await unsafeEmployeeService.AssignWithApplicationUser(employee.Id, user.Id);

            return await MapToUserModel(user);
        }

        public async Task<UserModel> GetUserByName(string username)
        {
            var response = await new WebRequestHelper().SendRequest($"{autharizationApiUrl}/api/account?name={username}", "get", "");
            UserAPIModel apiUser = GetObjectFromResponse<UserAPIModel>(response);

            return await MapToUserModel(apiUser);
        }

        public async Task<IEnumerable<string>> GetUserRoles(string name)
        {
            var response = await new WebRequestHelper().SendRequest($"{autharizationApiUrl}/api/account?name={name}", "get", "");
            UserAPIModel apiUser = GetObjectFromResponse<UserAPIModel>(response);

            return apiUser.Roles;
        }

        private async Task<UserAPIModel> RegisterUserWithRole(RegisterModel model, string role)
        {
            var response = await new WebRequestHelper().SendRequest($"{autharizationApiUrl}/api/account/register", "post", ToJson(MapToRegisterModelAPI(model, role)));
            UserAPIModel apiUser = GetObjectFromResponse<UserAPIModel>(response);

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

        private T GetObjectFromResponse<T>(WebResponse httpResponse)
        {
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(result);
            }      
        }

    }
}