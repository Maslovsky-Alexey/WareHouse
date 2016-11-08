using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WareHouse.AutharizationAPI.Repositories.Interfaces;
using WareHouse.AutharizationAPI.Repositories.Models;
using WareHouse.AutharizationAPI.Context.Models;
using Microsoft.AspNetCore.Identity;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WareHouse.AutharizationAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IApplicationUserRepository applicationUserService;
        private readonly IEncryptor encryptor;

        public AccountController(IApplicationUserRepository applicationUserService, IEncryptor encryptor)
        {
            this.applicationUserService = applicationUserService;
            this.encryptor = encryptor;
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

        [Route("register")]
        [HttpPost]
        public async Task<UserModel> Register([FromBody] RegisterModel model)
        {
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
        public async Task<UserModel> GetUserByName([FromQuery]string name)
        {
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

       
    }
}