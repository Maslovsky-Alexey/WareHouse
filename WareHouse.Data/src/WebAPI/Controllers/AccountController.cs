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


        public AccountController(ISafeAccountService safeAccountService, IUnsafeAccountService unsafeAccountService)
        {
            this.safeAccountService = safeAccountService;
            this.unsafeAccountService = unsafeAccountService;
        }

        [HttpPost("clients/actions/register")]
        [Authorize(Roles = "employee")]
        public async Task<UserModel> RegisterClient([FromBody] RegisterModel model)
        {
            return await unsafeAccountService.RegisterClient(model);
        }

        [HttpPost("employees/actions/register")]
        [Authorize(Roles = "employee")]
        public async Task<UserModel> RegisterEmployee([FromBody] RegisterModel model)
        {
            return await unsafeAccountService.RegisterEmployee(model);
        }

        [HttpPost("login")] 
        [AllowAnonymous]
        public async Task<bool> Login([FromBody] LoginModel model)
        {
            var result = await safeAccountService.Login(model);

            if (!string.IsNullOrEmpty(result))
            {
                HttpContext.AddAuthorizationHeader(result);
                return true;
            }
            else
            {
                HttpContext.Response.StatusCode = 401;
                return false;
            }   
        }

        [HttpGet("currentuser")]
        [Authorize]
        public async Task<UserModel> GetCurrentUser()
        {
            var user = await safeAccountService.GetCurrentUser(HttpContext);

            if (user == null)
                NotFound();

            return user;
        }


        [HttpGet("users/{username}")]
        [Authorize]
        public async Task<UserModel> GetUserByName(string username)
        {
            var user = await safeAccountService.GetUserByName(username);

            if (user == null)
                NotFound();

            return user;
        }
    }
}