using WareHouse.Data.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace WareHouse.Data.EF.Context.Mapping
{
    public class SupplyMapper : IMapper<Supply>
    {
        public void Map(EntityTypeBuilder<Supply> typeBuilder)
        {
            typeBuilder
                .HasOne(p => p.Item)
                .WithMany(p => p.Supplies)
                .HasForeignKey((Model.Supply p) => p.ItemId);

            typeBuilder
                .HasOne(p => p.Employee)
                .WithMany(p => p.Supplies)
                .HasForeignKey((Model.Supply p) => p.EmployeeId);

            typeBuilder
                .HasOne(p => p.Provider)
                .WithMany(p => p.Supplies)
                .HasForeignKey((Model.Supply p) => p.ProviderId);
        }
    }
}
