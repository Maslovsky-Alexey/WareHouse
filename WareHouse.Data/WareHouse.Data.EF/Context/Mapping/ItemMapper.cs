using WareHouse.Data.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace WareHouse.Data.EF.Context.Mapping
{
    public class ItemMapper : IMapper<Item>
    {
        public void Map(EntityTypeBuilder<Item> typeBuilder)
        {
     
        }
    }
}
