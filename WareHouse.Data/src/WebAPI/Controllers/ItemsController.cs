﻿using System;
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

    //TODO: модели лучше вынести в отдельную папку Models
    public class PageModel
    {
        public IEnumerable<Item> Items { get; set; }

        public int NextPage { get; set; }

        public int PrevPage { get; set; }
    }
    
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
            //TODO: Бизнес логика должна быть реализована в сервисе, для этого они и создавались
            var oldItem = (await items.GetItemByName(value.Name));

            var newCount = oldItem.Count - value.Count > 0 ? oldItem.Count - value.Count : 0;

            await items.UpdateCount(oldItem.ID, newCount);
        }

        [Route("GetPage/{page}")]
        [HttpPost("{page}")]
        public async Task<PageModel> GetPage(int page)
        {
            //TODO: Контроллер должен только передавать модель фильтрации (тот же OData) в сервис, логика должна выболняться в сервсие.
            var result = new PageModel();
            result.Items = (await items.GetAll()).Skip(page * 6).Take(6);

            result.PrevPage = page - 1 < 0 ? 0 : page - 1;

            var maxPage = (await items.Count() - 1) / 6;
            result.NextPage = page + 1 > maxPage ? maxPage : page + 1;

            return result;
        }
    }
}
