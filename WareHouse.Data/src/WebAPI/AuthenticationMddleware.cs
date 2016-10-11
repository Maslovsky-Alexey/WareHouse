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
    //TODO: Если запрос на авторизацию ? то как мы авторизируемся если мидлваре нам не дас пройти в контроллер ???
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
            var header = httpContext.Request.Headers.Where(x => x.Key == "Authorization").ToArray();

            //TODO: Если заголовок авторизации передан, то пользователь либо обязательно должен быть авторизован, либо ответ будет 400/401 без продолжения дальнейшей обработки. Т.е. ответ должен уйти прям отсюда.
            if (header.Count() == 1)
            {
                await SetHttpUserContext(header, httpContext);
            }                   

            await next.Invoke(httpContext);
        }

        private async Task SetHttpUserContext(IEnumerable<KeyValuePair<string, StringValues>> header, HttpContext httpContext)
        {
            var token = header.First().Value.First();

            // TODO: Если передан заголовок Authorization и он не в том виде, в котором ожидается, то это 400 BadRequest
            if (token.StartsWith("Bearer"))
            {
                try
                {
                    var name = TokenEncryptor.Decrypt(token.Substring(6));
                    var user = context.Users.FirstOrDefault(x => x.UserName == name);

                    // TODO: Если передан несуществущий/неправильный токен, то нужно вернуть сразу 401.
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
