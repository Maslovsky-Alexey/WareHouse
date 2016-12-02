using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.ServiceInterfaces.Unsafe;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WareHouse.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly ISafeOrderService safeOrderService;
        private readonly IUnsafeOrderService unsafeOrderService;

        public OrdersController(ISafeOrderService safeOrderService, IUnsafeOrderService unsafeOrderService)
        {
            this.safeOrderService = safeOrderService;
            this.unsafeOrderService = unsafeOrderService;
        }

        // GET: api/values

        [HttpGet]
        [Authorize(Roles = "employee")]
        public async Task<IEnumerable<OrderViewModel>> Get()
        {
            return await safeOrderService.GetAllAsViewModel();
        }

        [Route("{clientName}")]
        [HttpGet("{clientName}")]
        [Authorize]
        public async Task<IEnumerable<OrderViewModel>> GetClientOrders(string clientName)
        {
            return await safeOrderService.GetClientOrders(clientName);
        }
    }
}