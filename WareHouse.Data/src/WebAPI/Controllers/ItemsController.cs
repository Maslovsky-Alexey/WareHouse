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
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.MyOData;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{   
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private IItemService items;

        public ItemsController(IItemService items)
        {
            this.items = items;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Item>> Get()
        {
            return await items.GetAll();
        }


        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]Item value)
        {
            await items.AddOrUpdateCount(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Item value)
        {
            var item = await items.GetItem(id);

            item.Name = value.Name;
            item.Count = value.Count;
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task Delete([FromBody]Item value)
        {
            await items.RemoveItemByName(value);
        }

        [Route("UpdateCount")]
        [HttpPost]
        public async Task UpdateCount([FromBody]Item value)
        {     
            await items.SubCount(value);
        }

        [Route("GetPage/{page}")]
        [HttpPost("{page}")]
        public async Task<PageModel> GetPage(int page)
        {
            return await items.GetPage(page, MyOData.GetConfiguratesFromQueryString(Request.QueryString.Value));
        }
    }
}
