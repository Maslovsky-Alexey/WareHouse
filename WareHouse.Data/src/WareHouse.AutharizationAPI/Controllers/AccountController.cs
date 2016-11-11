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


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WareHouse.AutharizationAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IApplicationUserRepository applicationUserService;
        private readonly IEncryptor encryptor;
        private ISocialAPIRepository api;

        public AccountController(IApplicationUserRepository applicationUserService, ISocialAPIRepository socialApiRepository, IEncryptor encryptor)
        {
            this.applicationUserService = applicationUserService;
            this.encryptor = encryptor;
            api = socialApiRepository;
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
        public async Task<string> LoginVk([FromQuery(Name = "redirect_uri")] string redirectUri)
        {
            return api.GetUriToGetCode("http://localhost:11492/api/account/logincallback", new KeyValue("red", redirectUri));
        }

        [Route("logincallback")]
        public async Task LoginCallback([FromQuery(Name = "red")] string redirectUri)
        {
            var token = await api.GetAccessToken(Request, "http://localhost:11492/api/account/logincallback?red="+redirectUri);

            if (string.IsNullOrEmpty(redirectUri) || string.IsNullOrEmpty(token.Access_Token))
            {
                Response.Redirect("http://localhost:11492/");
            }
            else
            {
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