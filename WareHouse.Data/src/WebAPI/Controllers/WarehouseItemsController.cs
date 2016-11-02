using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.MyOData;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.ServiceInterfaces.Unsafe;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class WarehouseItemsController : Controller
    {
        private readonly ISafeWarehouseItemService safeWarehouseItemService;
        private readonly IUnsafeWarehouseItemService unsafeWarehouseItemService;

        public WarehouseItemsController(ISafeWarehouseItemService safeWarehouseItemService, IUnsafeWarehouseItemService unsafeWarehouseItemService)
        {
            this.safeWarehouseItemService = safeWarehouseItemService;
            this.unsafeWarehouseItemService = unsafeWarehouseItemService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<WarehouseItemViewModel>> Get()
        {
            return await safeWarehouseItemService.GetAllAsViewModel();
        }


        [Route("GetPage")]
        [HttpGet]
        [Authorize]
        public async Task<PageModel> GetPage([FromQuery]int page, [FromBody] MyODataConfigurates config)
        {
            return await safeWarehouseItemService.GetPage(page, config);
        }

        [Route("GetItemById/{id}")]
        [HttpGet("{id}")]
        [Authorize]
        public async Task<WarehouseItemViewModel> GetItemById(int id)
        {
            var item = await safeWarehouseItemService.GetItemByIdAsViewModel(id);

            if (item == null)
                NotFound();

            return item;
        }
    }
}