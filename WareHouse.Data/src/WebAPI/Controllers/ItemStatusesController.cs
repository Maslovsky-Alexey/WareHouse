using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.Model;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ItemStatusesController : Controller
    {
        private IItemStatusService itemStatuses;

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
