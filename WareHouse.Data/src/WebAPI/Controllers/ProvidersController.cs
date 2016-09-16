﻿using System;
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
            await providers.Add(value);
            await providers.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Provider value)
        {
            var item = await providers.GetItem(id);

            item.Name = value.Name;

            await providers.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task Delete([FromBody]Provider value)
        {
            var removingItem = await providers.GetItemByName(value.Name);

            if (removingItem != null)
                await providers.Remove(await providers.GetItem(removingItem.ID));
        }
    }
}