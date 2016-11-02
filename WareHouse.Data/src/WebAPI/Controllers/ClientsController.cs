using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Domain.Model;
using WareHouse.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.ServiceInterfaces.Unsafe;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        private readonly ISafeClientService safeClientService;
        private readonly IUnsafeClientService unsafeClientService;

        public ClientsController(ISafeClientService safeClientService, IUnsafeClientService unsafeClientService)
        {
            this.safeClientService = safeClientService;
            this.unsafeClientService = unsafeClientService;
        }

        // GET: api/values
        [HttpGet]
        [Authorize(Roles = "employee")]
        public async Task<IEnumerable<Client>> Get()
        {
            return await safeClientService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize(Roles = "employee")]
        public async Task<Client> Get(int id)
        {
            var client = await safeClientService.GetItem(id);

            if (client == null)
            {
                NotFound();
                return null;
            }

            return client;
        }

        // POST api/values
        [HttpPost]
        [Authorize(Roles = "employee")]
        public async Task Post([FromBody] Client value)
        {           
            var isSuccess = await unsafeClientService.AddWithoutRepetition(value);
            HttpContext.Response.StatusCode = isSuccess ? 201 : 409; //TODO: Лучше использовать this.Request.CreateResponse
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "employee")]
        public async Task Delete([FromBody] Client value)
        {
            var isRemoved = await unsafeClientService.RemoveClientByName(value);

            if (!isRemoved)
                NotFound();
        }
    }
}