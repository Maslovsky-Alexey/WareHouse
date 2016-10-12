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
        private IEncryptor encryptor;

        public AuthenticationMddleware(RequestDelegate next, UserManager<ApplicationUser> userManager, WareHouseDbContext context, IEncryptor encryptor)
        {
            this.next = next;
            this.userManager = userManager;
            this.context = context;
            this.encryptor = encryptor;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var header = httpContext.Request.Headers.Where(x => x.Key == "Authorization").ToArray();

           
            if (header.Count() == 1)
            {
                await SetHttpUserContext(header, httpContext);
            }

            if (httpContext.Response.StatusCode == 400 || httpContext.Response.StatusCode == 401)
                return;

            await next.Invoke(httpContext);
        }

        private async Task SetHttpUserContext(IEnumerable<KeyValuePair<string, StringValues>> header, HttpContext httpContext)
        {
            var token = header.First().Value.First();

            if (token.StartsWith("Bearer"))
            {
                try
                {
                    var name = encryptor.Decrypt(token.Substring(6));
                    var user = context.Users.FirstOrDefault(x => x.UserName == name);

                    if (user == null)
                        throw new Exception();

                    httpContext.User = new GenericPrincipal(new UserIndentity(user), (await userManager.GetRolesAsync(user)).ToArray());
                }
                catch
                {
                    httpContext.Response.StatusCode = 401;
                }
            }
            else
            {
                httpContext.Response.StatusCode = 400;
            }
        }
    }
}
