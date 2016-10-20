using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WareHouse.Data.Model;

namespace WareHouse.Data.EF.Context.Mapping
{
    public class ItemMapper : IMapper<Item>
    {
        public void Map(EntityTypeBuilder<Item> typeBuilder)
        {
        }
    }
}