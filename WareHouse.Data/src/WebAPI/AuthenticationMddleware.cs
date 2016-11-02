using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Primitives;
using WareHouse.Data.EF.Context;
using WareHouse.Data.Model;

namespace WebAPI
{
    public class AuthenticationMddleware
    {
        private readonly WareHouseDbContext context;
        private readonly IEncryptor encryptor;
        private readonly RequestDelegate next;
        private readonly UserManager<ApplicationUser> userManager;


        public AuthenticationMddleware(RequestDelegate next, UserManager<ApplicationUser> userManager,
            WareHouseDbContext context, IEncryptor encryptor)
        {
            this.next = next;
            this.userManager = userManager;
            this.context = context;
            this.encryptor = encryptor;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var header = httpContext.Request.Headers.Where(x => x.Key == "Authorization").ToArray();

            //await next.Invoke(httpContext);
            //return;

            if (header.Count() == 1)
                await SetHttpUserContext(header, httpContext);

            if ((httpContext.Response.StatusCode == 400) || (httpContext.Response.StatusCode == 401))
                return;

            await next.Invoke(httpContext);
        }

        private async Task SetHttpUserContext(IEnumerable<KeyValuePair<string, StringValues>> header,
            HttpContext httpContext)
        {
            var token = header.First().Value.First();

            if (token.StartsWith("Bearer"))
                try
                {
                    var name = encryptor.Decrypt(token.Substring(6));
                    ApplicationUser user;

                    lock (this)
                    {
                        user = context.Users.FirstOrDefault(x => x.UserName == name);
                    }

                    if (user == null)
                        throw new Exception();

                    httpContext.User = new GenericPrincipal(new UserIndentity(user),
                        (await userManager.GetRolesAsync(user)).ToArray());
                }
                catch
                {
                    httpContext.Response.StatusCode = 401;
                }
            else
                httpContext.Response.StatusCode = 400;
        }
    }
}