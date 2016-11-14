using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WareHouse.AutharizationAPI.Repositories.Interfaces;
using WareHouse.AutharizationAPI.Repositories.Models;
using WareHouse.AutharizationAPI.Context.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http.Authentication;
using WareHouse.AutharizationAPI.SocialNetworks.SocialAPI;
using WareHouse.AutharizationAPI.SocialNetworks.Interfaces;
using WareHouse.AutharizationAPI.HttpHelper;
using WareHouse.AutharizationAPI.SocialNetworks.Models;
using WareHouse.AutharizationAPI.Repositories;
using WareHouse.AutharizationAPI.SocialNetworks.UriExtension;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http.Extensions;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WareHouse.AutharizationAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IApplicationUserRepository applicationUserService;
        private readonly IEncryptor encryptor;

        private ISocialAPIRepositoryVk apiVk;
        private ISocialAPIRepositoryFacebook apiFacebook;

        public AccountController(IApplicationUserRepository applicationUserService, ISocialAPIRepositoryVk socialApiRepositoryVk, ISocialAPIRepositoryFacebook socialApiRepositoryFacebook, IEncryptor encryptor)
        {
            this.applicationUserService = applicationUserService;
            this.encryptor = encryptor;

            apiVk = socialApiRepositoryVk;
            apiFacebook = socialApiRepositoryFacebook;
        }

        [Route("login")]
        [HttpPost]
        public async Task<UserModel> Login([FromBody] LoginModel model)
        {
            if (await applicationUserService.Login(model) == OperationStatus.OK)
            {
                HttpContext.AddAuthorizationHeader(encryptor.Encrypt(model.Username));
                var a = await applicationUserService.GetUserByName(model.Username);
                return a;
            }

            Unauthorized();
            return null;
        }

        [Route("login/vk")]
        [HttpPost]
        public string LoginVk([FromQuery(Name = "redirect_uri")] string redirectUri)
        {
            return apiVk.GetUriToGetCode("http://localhost:11492/api/account/logincallback/vk", new KeyValue("redirectUri", redirectUri.Replace("/", "slash").Replace(":", "dvoetochie")));
        }

        [Route("login/facebook")]
        [HttpPost]
        public string LoginFacebook([FromQuery(Name = "redirect_uri")] string redirectUri)
        {
            return apiFacebook.GetUriToGetCode("http://localhost:11492/api/account/logincallback/facebook", new KeyValue("redirectUri", redirectUri.Replace("/", "slash").Replace(":", "dvoetochie")));
        }

        [Route("logincallback/vk")]
        public async Task LoginCallbackVk([FromQuery(Name = "redirectUri")] string redirectUri)
        {
            await LoginCallBack(apiVk, redirectUri);
        }

        [Route("logincallback/facebook")]
        public async Task LoginCallbackFacebook([FromQuery(Name = "redirectUri")] string redirectUri)
        {
            await LoginCallBack(apiFacebook, redirectUri);
        }

        private async Task LoginCallBack(ISocialAPIRepository api, string redirectUri)
        {
            var token = await api.GetAccessToken(Request, Request.GetDisplayUrl());

            if (redirectUri == null || string.IsNullOrEmpty(token.Access_Token))
            {
                Response.Redirect("http://localhost:11492/");
            }
            else
            {
                redirectUri = redirectUri.Replace("dvoetochie", ":").Replace("slash", "/");

                var user = await api.GetUserByToken(token);

                if (user == null)
                {
                    user = await api.RegisterUser(token, token.User_Id);
                }

                Response.Redirect(redirectUri + "?token=Bearer%20" + encryptor.Encrypt(user.UserName));
            }
        }

        [Route("register")]
        [HttpPost]
        public async Task<UserModel> Register([FromBody] RegisterModel model)
        {
            if (model.Password.Length < 5)
            {
                BadRequest();
                return null;
            }

            var user = await applicationUserService.Register(model);

            if (user != null)
            {
                HttpContext.AddAuthorizationHeader(encryptor.Encrypt(user.UserName));
                return user;
            }

            BadRequest();
            return null;
        }

        [HttpGet]
        public async Task<UserModel> GetUserByName([FromQuery]string name, [FromQuery] string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                name = encryptor.Decrypt(token);
            }

            if (string.IsNullOrEmpty(name))
            {
                BadRequest();
                return null;
            }

            var user = await applicationUserService.GetUserByName(name);

            if (user == null)
            {
                NotFound();
                return null;
            }

            return user;
        }

        [Route("{username}/roles")]
        [HttpPost]
        public async Task<UserModel> AddRole([FromQuery]string role, string username)
        {
            if (await applicationUserService.AddRole(username, role) == OperationStatus.Failed)
            {
                BadRequest();
                return null;
            }


            return await applicationUserService.GetUserByName(username);
        }











       
    }
}