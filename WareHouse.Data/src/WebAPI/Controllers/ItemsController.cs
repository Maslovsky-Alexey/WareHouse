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

        public ItemsController(ISafeItemService safeItemService)
        {
            this.safeItemService = safeItemService;
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