using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.Model.ViewModel;

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
            var header = httpContext.Request.Headers.Where(x => x.Key == "Authorization").ToArray(); // TODO: почему установка и чтение этого заголовка происходит не однообразно (HeadersHelper.AddAuthorizationHeader)

            //await next.Invoke(httpContext);
            //return;

            if (header.Count() == 1)
                await SetHttpUserContext(header, httpContext);

            if ((httpContext.Response.StatusCode == 400) || (httpContext.Response.StatusCode == 401))
                return;

            await next.Invoke(httpContext);
        }

        // TODO: async без await нет смысла использовать, мжно просто вернуть Task
        private async Task SetHttpUserContext(IEnumerable<KeyValuePair<string, StringValues>> header,
            HttpContext httpContext)
        {
            var token = header.First().Value.First();

            if (token.StartsWith("Bearer"))
                try
                {
                    UserModel user;

                    lock(this)
                    {
                        user = safeAccountService.GetUserByToken(token.Substring(6)).Result;
                                    
                        if (user == null)
                            throw new Exception(); // TODO: тут точно нужно исключение? тем более без как-то информации. Кажется это BadRequest с invalid token
                     
                        httpContext.User = new GenericPrincipal(new UserIndentity(new ApplicaitonUser { UserName = user.Login }),
                            (safeAccountService.GetUserRoles(user.Login).Result).ToArray());
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