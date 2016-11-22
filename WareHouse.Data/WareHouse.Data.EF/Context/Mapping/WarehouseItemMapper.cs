using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WareHouse.Data.Model;

namespace WareHouse.Data.EF.Context.Mapping
{
    public class WarehouseItemMapper : IMapper<WarehouseItem>
    {
        public void Map(EntityTypeBuilder<WarehouseItem> typeBuilder)
        {
            typeBuilder
                .HasOne(p => p.Item)
                .WithMany()
                .HasForeignKey(p => p.ItemId);
        }
    }
}