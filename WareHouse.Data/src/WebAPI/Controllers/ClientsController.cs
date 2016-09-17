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
    public class ClientsController : Controller
    {
        private ClientService clients;

        public ClientsController(WareHouseDbContext context)
        {
            clients = new ClientService(new ClientRepository(context));
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
            var client = await clients.GetItemByNameIgnoreCase(value.Name);

            if (client != null)
                return;

            await clients.Add(value);
            await clients.SaveChanges();        
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Client value)
        {
            var item = await clients.GetItem(id);

            item.Name = value.Name;

            await clients.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete([FromBody]Client value)
        {
            var removingItem = await clients.GetItemByNameIgnoreCase(value.Name);

            if (removingItem != null)
                await clients.Remove(await clients.GetItem(removingItem.ID));
        }
    }
}
