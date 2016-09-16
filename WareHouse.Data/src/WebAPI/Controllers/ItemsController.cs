using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Data.EF.Repository;
using WareHouse.Data.EF.Context;
using WareHouse.Domain.Model;
using Microsoft.AspNetCore.Cors;
using WareHouse.Domain.Service.ConcreteServices;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private ItemService items;

        public ItemsController(WareHouseDbContext context)
        {
            items = new ItemService(new ItemRepository(context));
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
            var item = await items.GetItemByNameIgnoreCase(value.Name);

            if (item != null)
            {
                await items.UpdateCount(item.ID, item.Count + value.Count);
            }
            else
            {
                await items.Add(value);
                await items.SaveChanges();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Item value)
        {
            var item = await items.GetItem(id);

            item.Name = value.Name;
            item.Count = value.Count;

            await items.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task Delete([FromBody]Item value)
        {
            var removingItem = await items.GetItemByName(value.Name);

            if (removingItem != null)
                await items.Remove(await items.GetItem(removingItem.ID));
        }

        [Route("UpdateCount")]
        [HttpPost]
        public async Task UpdateCount([FromBody]Item value)
        {
            var oldItem = (await items.GetItemByName(value.Name));

            var newCount = oldItem.Count - value.Count > 0 ? oldItem.Count - value.Count : 0;

            await items.UpdateCount(oldItem.ID, newCount);
        }
    }
}
