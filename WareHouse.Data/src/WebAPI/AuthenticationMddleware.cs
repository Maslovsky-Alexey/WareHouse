using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.Model.ViewModel;
using WebAPI.Controllers;
using WareHouse.HttpExtensions;

namespace WebAPI
{
    public class AuthenticationMddleware
    {
        private readonly RequestDelegate next;
        private readonly ISafeAccountService safeAccountService;


        public AuthenticationMddleware(RequestDelegate next, ISafeAccountService safeAccountService)
        {
            this.next = next;
            this.safeAccountService = safeAccountService;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var header = httpContext.GetAuthorizationHeader();

            if (header != null)
            {
                SetHttpUserContext(header, httpContext);
            }
               

            if ((httpContext.Response.StatusCode != 400) && (httpContext.Response.StatusCode != 401))
            {
                await next.Invoke(httpContext);
            }         
        }

        private void SetHttpUserContext(string token, HttpContext httpContext)
        {
            if (token.StartsWith("Bearer"))
            {
                SetUser(token, httpContext);
            }
            else
            {
                httpContext.Response.StatusCode = 400;
            }             
        }

        private void SetUser(string token, HttpContext httpContext)
        {
            try
            {
                UserModel user;

                lock (this)
                {
                    user = safeAccountService.GetUserByToken(token.Substring(6)).Result;

                    if (user == null)
                    {
                        httpContext.Response.StatusCode = 400;
                        return;
                    }

                    httpContext.User = new GenericPrincipal(new UserIndentity(new ApplicaitonUser { UserName = user.Login }),
                        (safeAccountService.GetUserRoles(user.Login).Result).ToArray());
                }
            }
            catch
            {
                httpContext.Response.StatusCode = 401;
            }
        }
    }
}