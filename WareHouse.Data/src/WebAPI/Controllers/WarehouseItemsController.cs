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
    public class WarehouseItemsController : Controller
    {
        private IWarehouseItemService warehouseItems;

        public WarehouseItemsController(IWarehouseItemService warehouseItems)
        {
            this.warehouseItems = warehouseItems;
        }

        [HttpGet]
        public async Task<IEnumerable<WarehouseItem>> Get()
        {
            return await warehouseItems.GetAll();
        }

        [HttpPost]
        public async Task Post([FromBody]Item value)
        {
            
        }
    }
}
