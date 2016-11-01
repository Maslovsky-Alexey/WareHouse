using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Domain.Model;
using WareHouse.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.ServiceInterfaces.Unsafe;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private readonly ISafeItemService safeItemService;
        private readonly IUnsafeItemService unsafeItemService; //TODO: Он не используется в коде, нужно сделать clean up кода. Наличие лишних зависимостей усложняет восприятие и гибкость кода.

        public ItemsController(ISafeItemService safeItemService, IUnsafeItemService unsafeItemService)
        {
            this.safeItemService = safeItemService;
            this.unsafeItemService = unsafeItemService;
        }

        // GET: api/values
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<Item>> Get()
        {
            return await safeItemService.GetAll();
        }
    }
}