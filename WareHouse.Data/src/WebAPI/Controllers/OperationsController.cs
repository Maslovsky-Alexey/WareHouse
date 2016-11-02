using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.ServiceInterfaces.Unsafe;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class OperationsController : Controller
    {
        private readonly ISafeOperationService safeOperationService;
        private readonly IUnsafeOperationService unsafeOperationService;

        public OperationsController(ISafeOperationService safeOperationService, IUnsafeOperationService unsafeOperationService)
        {
            this.safeOperationService = safeOperationService;
            this.unsafeOperationService = unsafeOperationService;
        }

        [Route("Supply")]
        [HttpPost]
        [Authorize(Roles = "employee")]
        public async Task AddSupply([FromBody] SupplyViewModel value)
        {
            var status = await unsafeOperationService.AddSupply(value);

            if (status == WareHouse.Data.Repository.OperationStatus.Error)
            {
                HttpContext.Response.StatusCode = 500;
            }         
        }

        [Route("Order")]
        [HttpPost]
        [Authorize(Roles = "employee")]
        public async Task AddOrder([FromBody] OrderViewModel value)
        {
            var status = await unsafeOperationService.AddOrder(value);

            if (status == WareHouse.Data.Repository.OperationStatus.Error)
                HttpContext.Response.StatusCode = 500;
        }
                
        [Route("Order/Actions/Confirm/{id}")]
        [HttpPut("{id}")]
        [Authorize]
        public async Task ConfirmOrder(int id)
        {
            if (await unsafeOperationService.ConfirmOrder(id) == ConfirmationStatus.NotFound)
                NotFound();
        }

        [Route("Supply/Actions/Confirm/{id}")]
        [HttpPut("{id}")]
        [Authorize(Roles = "employee")]
        public async Task ConfirmSupply(int id)
        {
            if (await unsafeOperationService.ConfirmSupply(id) == ConfirmationStatus.NotFound)
                NotFound();
        }

        [Route("Order/Actions/Return/{id}")]
        [HttpPut("{id}")]
        [Authorize]
        public async Task ReturnOrder(int id)
        {
            if (await unsafeOperationService.ReturnOrder(id) == ReturnStatus.NotFound)
                NotFound();
        }

        [Route("Supply/Actions/Return/{id}")]
        [HttpPut("{id}")]
        [Authorize(Roles = "employee")]
        public async Task ReturnSupply(int id)
        {
            if (await unsafeOperationService.ReturnSupply(id) == ReturnStatus.NotFound)
                NotFound();
        }

        [Route("Item")]
        [HttpPost]
        [Authorize(Roles = "employee")]
        public async Task AddItemWithoutRepetition([FromBody] Item value)
        {
            await unsafeOperationService.AddItemWithoutRepetition(value);
        }
    }
}