using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WareHouse.Data.Model;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using WareHouse.Domain.Model.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WareHouse.Domain.ServiceInterfaces;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("RegisterClient")]
        [Authorize(Roles = "employee")]
        public async Task<UserModel> RegisterClient([FromBody]RegisterModel model)
        {
            return await accountService.RegisterClient(model);
        }

        [HttpPost("RegisterEmployee")]
        [Authorize(Roles = "employee")]
        public async Task<UserModel> RegisterEmployee([FromBody]RegisterModel model)
        {
            return await accountService.RegisterEmployee(model);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<bool> Login([FromBody]LoginModel model)
        {
            return await accountService.Login(model);
        }

        [HttpGet("GetCurrentUser")]
        [AllowAnonymous]
        public async Task<UserModel> GetCurrentUser()
        {
            return await accountService.GetCurrentUser(HttpContext);
        }
    }
}
