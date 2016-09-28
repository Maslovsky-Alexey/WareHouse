using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;

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
        public async Task<IEnumerable<WarehouseItemViewModel>> Get()
        {
            return await warehouseItems.GetAllAsViewModel();
        }

        [HttpPost]
        public async Task Post([FromBody]WarehouseItemViewModel value)
        {
            await warehouseItems.AddOrUpdateAsViewModel(value);
        }

        [Route("AddSupply")]
        [HttpPost]
        public async Task AddSupply([FromBody]SupplyViewModel value)
        {
            await warehouseItems.AddSupply(value);
        }

        [Route("AddOrder")]
        [HttpPost]
        public async Task AddOrder([FromBody]OrderViewModel value)
        {
            await warehouseItems.AddOrder(value);
        }
    }
}
