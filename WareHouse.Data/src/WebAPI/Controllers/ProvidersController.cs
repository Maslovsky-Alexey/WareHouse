using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Data.EF.Context;
using WareHouse.Data.EF.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Service.ConcreteServices;
using Microsoft.AspNetCore.Authorization;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.ServiceInterfaces.Unsafe;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProvidersController : Controller
    {
        private readonly ISafeProviderService safeProviderService;
        private readonly IUnsafeProviderService unsafeProviderService;

        public ProvidersController(ISafeProviderService safeProviderService, IUnsafeProviderService unsafeProviderService)
        {
            this.safeProviderService = safeProviderService;
            this.unsafeProviderService = unsafeProviderService;
        }

        // GET: api/values
        [HttpGet]
        [Authorize(Roles = "employee")]
        public async Task<IEnumerable<Provider>> Get()
        {
            return await safeProviderService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize(Roles = "employee")]
        public async Task<Provider> Get(int id)
        {
            return await safeProviderService.GetItem(id);
        }

        [HttpGet("{name}")]
        [Authorize(Roles = "employee")]
        public async Task<Provider> Get(string name)
        {
            return await safeProviderService.GetProviderByName(name, true);
        }

        // POST api/values
        [HttpPost]
        [Authorize(Roles = "employee")]
        public async Task Post([FromBody] Provider value)
        {
            await unsafeProviderService.AddWithoutRepetition(value);
        }

        // DELETE api/values/5
        [HttpDelete]
        [Authorize(Roles = "employee")]
        public async Task Delete([FromBody] Provider value)
        {
            await unsafeProviderService.RemoveProviderByName(value);
        }
    }
}