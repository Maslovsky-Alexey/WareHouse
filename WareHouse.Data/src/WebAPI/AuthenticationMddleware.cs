using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Data.EF.Context;
using System.Text;
using Microsoft.AspNetCore.Identity;
using WareHouse.Data.Model;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.Extensions.Primitives;

namespace WebAPI
{
    public class AuthenticationMddleware
    {
        private UserManager<ApplicationUser> userManager;
        private RequestDelegate next;
        private WareHouseDbContext context;

        public AuthenticationMddleware(RequestDelegate next, UserManager<ApplicationUser> userManager, WareHouseDbContext context)
        {
            this.next = next;
            this.userManager = userManager;
            this.context = context;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var header = httpContext.Request.Headers.Where(x => x.Key == "Authorization");

            if (header.Count() == 1)
            {
                await SetHttpUserContext(header, httpContext);
            }                   

            await next.Invoke(httpContext);
        }

        private async Task SetHttpUserContext(IEnumerable<KeyValuePair<string, StringValues>> header, HttpContext httpContext)
        {
            var token = header.First().Value.First();

            if (token.Contains("Bearer"))
            {
                try
                {
                    var name = TokenEncryptor.Decrypt(token.Replace("Bearer ", ""));
                    var user = context.Users.FirstOrDefault(x => x.UserName == name);

                    if (user != null)
                        httpContext.User = new GenericPrincipal(new UserIndentity(user), (await userManager.GetRolesAsync(user)).ToArray());
                }
                catch
                {

                }
            }
        }
    }
}
