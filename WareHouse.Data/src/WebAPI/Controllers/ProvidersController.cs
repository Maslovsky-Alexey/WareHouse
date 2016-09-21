using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Domain.Service.ConcreteServices;
using WareHouse.Data.EF.Context;
using WareHouse.Data.EF.Repository;
using WareHouse.Domain.Model;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProvidersController : Controller
    {
        private ProviderService providers;

        public ProvidersController(WareHouseDbContext context)
        {
            providers = new ProviderService(new ProviderRepository(context));
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Provider>> Get()
        {
            return await providers.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Provider> Get(int id)
        {
            return await providers.GetItem(id);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]Provider value) 
        {
            await providers.AddWithoutRepetition(value);

        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task Delete([FromBody]Provider value)
        {
            await providers.RemoveProviderByName(value);
        }
    }
}
