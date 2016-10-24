using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrderService items;

        public OrdersController(IOrderService items)
        {
            this.items = items;
        }

        // GET: api/values

        [HttpGet]
        [Authorize(Roles = "employee")]
        public async Task<IEnumerable<OrderViewModel>> Get()
        {
            return await items.GetAllAsViewModel();
        }

        [Route("GetClientOrders/{clientName}")]
        [HttpGet("{clientName}")]
        [Authorize]
        public async Task<IEnumerable<OrderViewModel>> GetClientOrders(string clientName)
        {
            return await items.GetClientOrders(clientName);
        }
    }
}