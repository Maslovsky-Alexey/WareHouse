using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Domain.Model;
using WareHouse.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private readonly IItemService items;

        public ItemsController(IItemService items)
        {
            this.items = items;
        }

        // GET: api/values
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<Item>> Get()
        {
            return await items.GetAll();
        }
    }
}