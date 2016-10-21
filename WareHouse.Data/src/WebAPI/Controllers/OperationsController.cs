using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.ServiceInterfaces;

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
        public async Task AddSupply([FromBody] SupplyViewModel value)
        {
            await operationService.AddSupply(value);
        }

        [Route("AddOrder")]
        [HttpPost]
        public async Task AddOrder([FromBody] OrderViewModel value)
        {
            await operationService.AddOrder(value);
        }
                
        [Route("ConfirmOrder/{id}")]
        [HttpPut("{id}")]
        public async Task ConfirmOrder(int id)
        {
            await operationService.ConfirmOrder(id);
        }

        [Route("ConfirmSupply/{id}")]
        [HttpPut("{id}")]
        public async Task ConfirmSupply(int id)
        {
            await operationService.ConfirmSupply(id);
        }

        [Route("ReturnOrder/{id}")]
        [HttpPut("{id}")]
        public async Task ReturnOrder(int id)
        {
            await operationService.ReturnOrder(id);
        }

        [Route("ReturnSupply/{id}")]
        [HttpPut("{id}")]
        public async Task ReturnSupply(int id)
        {
            await operationService.ReturnSupply(id);
        }

        [Route("AddItemWithoutRepetition")]
        [HttpPost]
        public async Task AddItemWithoutRepetition([FromBody] Item value)
        {
            await operationService.AddItemWithoutRepetition(value);
        }
    }
}