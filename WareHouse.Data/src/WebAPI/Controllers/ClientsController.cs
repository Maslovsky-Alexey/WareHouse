using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Domain.Service.ConcreteServices;
using WareHouse.Data.EF.Context;
using WareHouse.Data.EF.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Data.Repository;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        private IClientService clients;

        public ClientsController(IClientService clients)
        {
            this.clients = clients;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Client>> Get()
        {
            return await clients.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Client> Get(int id)
        {
            return await clients.GetItem(id);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]Client value)
        {
            await clients.AddWithoutRepetition(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete([FromBody]Client value)
        {
            await clients.RemoveClientByName(value);
        }
    }
}
