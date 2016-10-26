using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.ServiceInterfaces.Unsafe;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly ISafeAccountService safeAccountService;
        private readonly IUnsafeAccountService unsafeAccountService;

        private readonly IEncryptor encryptor;

        public AccountController(ISafeAccountService safeAccountService, IUnsafeAccountService unsafeAccountService, IEncryptor encryptor)
        {
            this.safeAccountService = safeAccountService;
            this.unsafeAccountService = unsafeAccountService;

            this.encryptor = encryptor;
        }

        [HttpPost("RegisterClient")]
        [Authorize(Roles = "employee")]
        public async Task<UserModel> RegisterClient([FromBody] RegisterModel model)
        {
            return await unsafeAccountService.RegisterClient(model);
        }

        [HttpPost("RegisterEmployee")]
        [Authorize(Roles = "employee")]
        public async Task<UserModel> RegisterEmployee([FromBody] RegisterModel model)
        {
            return await unsafeAccountService.RegisterEmployee(model);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<bool> Login([FromBody] LoginModel model)
        {
            var result = await safeAccountService.Login(model);

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
            return await safeAccountService.GetCurrentUser(HttpContext);
        }

        [HttpGet("GetUserByName/{username}")]
        [Authorize]
        public async Task<UserModel> GetUserByName(string username)
        {
            var user = await safeAccountService.GetUserByName(username);

            if (user == null)
                HttpContext.Response.StatusCode = 404;

            return user;
        }
    }
}