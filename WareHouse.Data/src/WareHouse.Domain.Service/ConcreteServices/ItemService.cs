using System;
using Microsoft.EntityFrameworkCore;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class ItemRepository : BaseService<Item>, IItemService
    {
        public ItemRepository(DbSet<Item> items) : base(items)
        {
        }        
    }
}
