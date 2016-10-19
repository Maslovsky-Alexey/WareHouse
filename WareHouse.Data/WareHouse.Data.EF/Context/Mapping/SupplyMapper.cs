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
                .WithMany()
                .HasForeignKey(p => p.ItemId);

            typeBuilder
                .HasOne(p => p.Employee)
                .WithMany()
                .HasForeignKey(p => p.EmployeeId);

            typeBuilder
                .HasOne(p => p.Provider)
                .WithMany()
                .HasForeignKey(p => p.ProviderId);

            typeBuilder
                .HasOne(p => p.Status)
                .WithMany()
                .HasForeignKey(p => p.StatusId);
        }
    }
}
