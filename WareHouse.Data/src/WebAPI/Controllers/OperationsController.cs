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

        [Route("AddSupply")] //TODO: URI не должен содержать глаголы, это должна быть сущность. А действие, которое нужно выполнить, задается http мотодом. Вот краткая статейка https://tproger.ru/translations/http-api-design-guide/.
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

        [Route("AddOrder")]
        [HttpPost]
        [Authorize(Roles = "employee")]
        public async Task AddOrder([FromBody] OrderViewModel value)
        {
            var status = await unsafeOperationService.AddOrder(value);

            if (status == WareHouse.Data.Repository.OperationStatus.Error)
                HttpContext.Response.StatusCode = 500;
        }
                
        [Route("ConfirmOrder/{id}")]
        [HttpPut("{id}")]
        [Authorize]
        public async Task ConfirmOrder(int id)
        {
            await unsafeOperationService.ConfirmOrder(id);
        }

        [Route("ConfirmSupply/{id}")]
        [HttpPut("{id}")]
        [Authorize(Roles = "employee")]
        public async Task ConfirmSupply(int id)
        {
            await unsafeOperationService.ConfirmSupply(id);
        }

        [Route("ReturnOrder/{id}")]
        [HttpPut("{id}")]
        [Authorize]
        public async Task ReturnOrder(int id)
        {
            await unsafeOperationService.ReturnOrder(id);
        }

        [Route("ReturnSupply/{id}")]
        [HttpPut("{id}")]
        [Authorize(Roles = "employee")]
        public async Task ReturnSupply(int id) //TODO: 404 здесь не может быть?
        {
            await unsafeOperationService.ReturnSupply(id);
        }

        [Route("AddItemWithoutRepetition")]
        [HttpPost]
        [Authorize(Roles = "employee")]
        public async Task AddItemWithoutRepetition([FromBody] Item value)
        {
            await unsafeOperationService.AddItemWithoutRepetition(value);
        }
    }
}