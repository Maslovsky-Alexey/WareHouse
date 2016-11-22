using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Net;
using HttpWebHelperLibrary;
using WareHouse.AuthAPIHelper.AutharizationAPIModel;

namespace WareHouse.AuthAPIHelper
{
    public class AuthHelper : IAuthHelper
    {
        private readonly string autharizationApiUrl;
        private readonly IWebRequestHelper webRequestHelper;

        public AuthHelper(
            string autharizationApiUrl,
            IWebRequestHelper webRequestHelper)
        {
            this.autharizationApiUrl = autharizationApiUrl;
            this.webRequestHelper = webRequestHelper;
        }

        public async Task<string> Login(PasswordNameModel model)
        {
            var response = await webRequestHelper.SendRequest($"{autharizationApiUrl}/api/account/login", "post", ToJson(model));

            UserAPIModel apiUser = webRequestHelper.GetObjectFromResponse<UserAPIModel>(response);

            if (apiUser == null)
                return null;

            return !string.IsNullOrEmpty(response.Headers["Authorization"]) ? response.Headers["Authorization"] : null;
        }

        public async Task<UserAPIModel> GetUserByName(string username)
        {
            var response = await webRequestHelper.SendRequest($"{autharizationApiUrl}/api/account?name={username}", "get", "");

            return webRequestHelper.GetObjectFromResponse<UserAPIModel>(response);
        }

        public async Task<UserAPIModel> GetUserByToken(string token)
        {
            var response = await webRequestHelper.SendRequest($"{autharizationApiUrl}/api/account?token={token}", "get", "");

            return webRequestHelper.GetObjectFromResponse<UserAPIModel>(response);
        }

        public async Task<IEnumerable<string>> GetUserRoles(string name)
        {
            var response = await webRequestHelper.SendRequest($"{autharizationApiUrl}/api/account?name={name}", "get", "");
            UserAPIModel apiUser = webRequestHelper.GetObjectFromResponse<UserAPIModel>(response);

            return apiUser.Roles;
        }

        public async Task<UserAPIModel> RegisterUserWithRole(string name, string password, string role)
        {
            var response = await webRequestHelper.SendRequest($"{autharizationApiUrl}/api/account/register", "post", ToJson(new RegisterModelAPI
            {
                Password = password,
                Username = name,
                Roles = new string[] { role }
            }));

            UserAPIModel apiUser = webRequestHelper.GetObjectFromResponse<UserAPIModel>(response);

            return apiUser;
        }


        private string ToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

        public async Task<UserAPIModel> AddRole(string username, string role)
        {
            var response = await webRequestHelper.SendRequest($"{autharizationApiUrl}/api/account/{username}/roles/?role={role}", "post", null);

            UserAPIModel apiUser = webRequestHelper.GetObjectFromResponse<UserAPIModel>(response);

            return apiUser;
        }
    }
}