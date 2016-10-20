using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WareHouse.Data.Model;

namespace WareHouse.Data.EF.Context.Mapping
{
    public class ItemStatusMapper : IMapper<ItemStatus>
    {
        public void Map(EntityTypeBuilder<ItemStatus> typeBuilder)
        {
            typeBuilder
                .Property(x => x.Status)
                .HasDefaultValue(Status.Processing);
        }
    }
}