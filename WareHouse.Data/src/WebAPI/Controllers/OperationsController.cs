using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class OperationsController : Controller
    {
        private readonly IOperationService operationService;

        public OperationsController(IOperationService operationService)
        {
            this.operationService = operationService;
        }

        [Route("AddSupply")]
        [HttpPost]
        [Authorize(Roles = "employee")]
        public async Task AddSupply([FromBody] SupplyViewModel value)
        {
            var status = await operationService.AddSupply(value);

            if (status == WareHouse.Data.Repository.OperationStatus.Error)
                HttpContext.Response.StatusCode = 500;
        }

        [Route("AddOrder")]
        [HttpPost]
        [Authorize(Roles = "employee")]
        public async Task AddOrder([FromBody] OrderViewModel value)
        {
            var status = await operationService.AddOrder(value);

            if (status == WareHouse.Data.Repository.OperationStatus.Error)
                HttpContext.Response.StatusCode = 500;
        }
                
        [Route("ConfirmOrder/{id}")]
        [HttpPut("{id}")]
        [Authorize]
        public async Task ConfirmOrder(int id)
        {
            await operationService.ConfirmOrder(id);
        }

        [Route("ConfirmSupply/{id}")]
        [HttpPut("{id}")]
        [Authorize(Roles = "employee")]
        public async Task ConfirmSupply(int id)
        {
            await operationService.ConfirmSupply(id);
        }

        [Route("ReturnOrder/{id}")]
        [HttpPut("{id}")]
        [Authorize]
        public async Task ReturnOrder(int id)
        {
            await operationService.ReturnOrder(id);
        }

        [Route("ReturnSupply/{id}")]
        [HttpPut("{id}")]
        [Authorize(Roles = "employee")]
        public async Task ReturnSupply(int id)
        {
            await operationService.ReturnSupply(id);
        }

        [Route("AddItemWithoutRepetition")]
        [HttpPost]
        [Authorize(Roles = "employee")]
        public async Task AddItemWithoutRepetition([FromBody] Item value)
        {
            await operationService.AddItemWithoutRepetition(value);
        }
    }
}