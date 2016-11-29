using System.Threading.Tasks;
using WareHouse.Data.Model;

namespace WareHouse.Data.Repository
{
    public interface IItemRepository : IRepository<Item>
    {
        Task<Item> GetItemByName(string name, bool ignoreCase);
    }
}