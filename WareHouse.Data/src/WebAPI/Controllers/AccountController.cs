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
using Microsoft.Extensions.Primitives;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        private IEncryptor encryptor;

        public AccountController(IAccountService accountService, IEncryptor encryptor)
        {
            this.accountService = accountService;
            this.encryptor = encryptor;
        }

        [HttpPost("RegisterClient")]
        [Authorize(Roles = "employee")]
        public async Task<UserModel> RegisterClient([FromBody]RegisterModel model)
        {
            return await accountService.RegisterClient(model);
        }

        [HttpPost("RegisterEmployee")]
        [AllowAnonymous]
        public async Task<UserModel> RegisterEmployee([FromBody]RegisterModel model)
        {
            return await accountService.RegisterEmployee(model);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<bool> Login([FromBody]LoginModel model)
        {
            var result = await accountService.Login(model);

            if (result)
            {
                HeadersHelper.AddAuthorizationHeader(HttpContext, encryptor.Encrypt(model.Username));
            }

            return result;
        }

        [HttpGet("Login")]
        [AllowAnonymous]
        public async Task<bool> Login()
        {
            var result = await accountService.Login(new LoginModel { Password = "admin", Username = "admin" });

            if (result)
            {
                HttpContext.Response.Headers.Add("Authorization", new[] { "Bearer " + encryptor.Encrypt("admin") });
            }

            return result;
        }

        [HttpGet("GetCurrentUser")]
        [Authorize(Roles = "employee")]
        public async Task<UserModel> GetCurrentUser()
        {
            return await accountService.GetCurrentUser(HttpContext);
        }

        [HttpGet("GetUserByName/{username}")]
        [Authorize(Roles = "employee, client")]
        public async Task<UserModel> GetUserByName(string username)
        {
            return await accountService.GetUserByName(username);
        }
    }
}
