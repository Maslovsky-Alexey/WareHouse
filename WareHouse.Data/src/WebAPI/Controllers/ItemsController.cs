using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Data.EF.Repository;
using WareHouse.Data.EF.Context;
using WareHouse.Data.Model;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private ItemRepository items;
        private WareHouseDbContext context;

        public ItemsController(WareHouseDbContext context)
        {
            this.context = context;
            items = new ItemRepository(context);
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Item>> Get()
        {
            return await items.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Item> Get(int id)
        {
            return await items.GetItem(id);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]Item value)
        {
            await items.Add(value);

            context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Item value)
        {
            var item = await items.GetItem(id);

            item.Name = value.Name;
            item.Count = value.Count;

            context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await items.Remove(await items.GetItem(id));

            context.SaveChanges();
        }
    }
}
