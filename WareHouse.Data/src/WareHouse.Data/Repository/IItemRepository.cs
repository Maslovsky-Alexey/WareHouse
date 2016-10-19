using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.Model;

namespace WareHouse.Data.Repository
{
    public interface IItemRepository : IRepository<Model.Item>
    {
        Task<Item> GetItemByName(string name, bool ignoreCase);

        Task<int> UpdateCount(int itemId, int deltaCount);
    }
}
