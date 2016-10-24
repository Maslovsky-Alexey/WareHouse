using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.ServiceInterfaces;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        private readonly IEncryptor encryptor;

        public AccountController(IAccountService accountService, IEncryptor encryptor)
        {
            this.accountService = accountService;
            this.encryptor = encryptor;
        }

        [HttpPost("RegisterClient")]
        [Authorize(Roles = "employee")]
        public async Task<UserModel> RegisterClient([FromBody] RegisterModel model)
        {
            return await accountService.RegisterClient(model);
        }

        [HttpPost("RegisterEmployee")]
        [Authorize(Roles = "employee")]
        public async Task<UserModel> RegisterEmployee([FromBody] RegisterModel model)
        {
            return await accountService.RegisterEmployee(model);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<bool> Login([FromBody] LoginModel model)
        {
            var result = await accountService.Login(model);

            if (result)
                HeadersHelper.AddAuthorizationHeader(HttpContext, encryptor.Encrypt(model.Username));
            else
                HttpContext.Response.StatusCode = 401;

            return result;
        }

        [HttpGet("GetCurrentUser")]
        [Authorize]
        public async Task<UserModel> GetCurrentUser()
        {
            return await accountService.GetCurrentUser(HttpContext);
        }

        [HttpGet("GetUserByName/{username}")]
        [Authorize]
        public async Task<UserModel> GetUserByName(string username)
        {
            var user = await accountService.GetUserByName(username);

            if (user == null)
                HttpContext.Response.StatusCode = 404;

            return user;
        }
    }
}