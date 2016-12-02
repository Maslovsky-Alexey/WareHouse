using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Domain.Model;
using WareHouse.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.ServiceInterfaces.Unsafe;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WareHouse.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ItemStatusesController : Controller
    {
        private readonly ISafeItemStatusService safeItemStatusService;
        private readonly IUnsafeItemStatusService unsafeItemStatusService;

        public ItemStatusesController(ISafeItemStatusService safeItemStatusService, IUnsafeItemStatusService unsafeItemStatusService)
        {
            this.safeItemStatusService = safeItemStatusService;
            this.unsafeItemStatusService = unsafeItemStatusService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<ItemStatus>> Get()
        {
            return await safeItemStatusService.GetAll();
        }
    }
}