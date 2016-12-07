using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Domain.Model;
using WareHouse.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.ServiceInterfaces.Unsafe;
using WareHouse.PollingEventManager.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WareHouse.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class NotificationsController : Controller
    {
        private readonly ISafeNotificationsService notificationsService;

        public NotificationsController(ISafeNotificationsService notificationsService)
        {
            this.notificationsService = notificationsService;
        }

        // GET: api/values
        [HttpGet("{ticks}")]

        public async Task<IEnumerable<EventModel>> GetNotifications(long ticks)
        {
            return await notificationsService.GetNotifications(ticks);
        }
    }
}