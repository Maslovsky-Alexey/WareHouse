using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WareHouse.Data.EF.Context;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;

namespace WareHouse.Data.EF.Repository
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(WareHouseDbContext context) : base(context)
        {
        }

        public async Task<Item> GetItemByName(string name, bool ignoreCase)
        {
            if (ignoreCase)
                return await context.Items.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            return await context.Items.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}