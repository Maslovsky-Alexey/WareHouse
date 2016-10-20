using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Domain.Model;
using WareHouse.Domain.ServiceInterfaces;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ItemStatusesController : Controller
    {
        private readonly IItemStatusService itemStatuses;

        public ItemStatusesController(IItemStatusService itemStatuses)
        {
            this.itemStatuses = itemStatuses;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemStatus>> Get()
        {
            return await itemStatuses.GetAll();
        }
    }
}