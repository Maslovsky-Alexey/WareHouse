using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WareHouse.Data.Model;

namespace WareHouse.Data.EF.Context.Mapping
{
    public class OrderMapper : IMapper<Order>
    {
        public void Map(EntityTypeBuilder<Order> typeBuilder)
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
                .HasOne(p => p.Client)
                .WithMany()
                .HasForeignKey(p => p.ClientId);

            typeBuilder
                .HasOne(p => p.Status)
                .WithMany()
                .HasForeignKey(p => p.StatusId);
        }
    }
}