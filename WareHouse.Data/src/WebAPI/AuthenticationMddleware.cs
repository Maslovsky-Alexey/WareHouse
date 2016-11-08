using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using WareHouse.Data.EF.Context;
using WareHouse.Data.Model;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.Model.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebAPI
{
    public class AuthenticationMddleware
    {
        private readonly IEncryptor encryptor;
        private readonly RequestDelegate next;
        private readonly ISafeAccountService safeAccountService;


        public AuthenticationMddleware(RequestDelegate next, ISafeAccountService safeAccountService, IEncryptor encryptor)
        {
            this.next = next;
            this.safeAccountService = safeAccountService;
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
                    UserModel user;

                    lock(this)
                    {
                        user = safeAccountService.GetUserByName(name).Result;
                                    

                    if (user == null)
                        throw new Exception();
                     
                    httpContext.User = new GenericPrincipal(new UserIndentity(new ApplicaitonUser { UserName = user.Name }),
                        (safeAccountService.GetUserRoles(name).Result).ToArray());
                    }
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