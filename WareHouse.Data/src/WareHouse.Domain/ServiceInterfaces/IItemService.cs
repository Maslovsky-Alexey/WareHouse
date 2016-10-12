using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.MyOData;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IItemService : IService<Domain.Model.Item, Data.Model.Item>
    {
        Task<Model.Item> GetItemByName(string name, bool ignoreCase);

        Task AddOrUpdateCount(Item value);

        Task SubCount(Item value);

        Task RemoveItem(Item value);

    }
}
