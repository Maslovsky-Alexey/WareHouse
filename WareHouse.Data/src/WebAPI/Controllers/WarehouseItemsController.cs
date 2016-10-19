using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.MyOData;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public async Task<IEnumerable<WarehouseItemViewModel>> Get()
        {
            return await warehouseItems.GetAllAsViewModel();
        }


        [Route("GetPage/{page}")]
        [HttpGet("{page}")]
        [Authorize]
        public async Task<PageModel> GetPage(int page, [FromBody]MyODataConfigurates config)
        {
            return await warehouseItems.GetPage(page, config);
        }

        [Route("GetItemById/{id}")]
        [HttpGet("{id}")]
        [Authorize]
        public async Task<WarehouseItemViewModel> GetItemById(int id)
        {
            return await warehouseItems.GetItemByIdAsViewModel(id);
        }
    }
}
