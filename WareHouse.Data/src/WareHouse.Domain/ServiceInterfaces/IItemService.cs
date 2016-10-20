using System.Threading.Tasks;
using WareHouse.Domain.Model;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IItemService : IService<Item, Data.Model.Item>
    {
        Task<Item> GetItemByName(string name, bool ignoreCase);

        Task AddWithoutRepetition(Item item);
    }
}