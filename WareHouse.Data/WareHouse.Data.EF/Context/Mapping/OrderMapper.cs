using WareHouse.Data.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace WareHouse.Data.EF.Context.Mapping
{
    public class OrderMapper : IMapper<Order>
    {
        public void Map(EntityTypeBuilder<Order> typeBuilder)
        {
            typeBuilder
               .HasOne(p => p.Item)
               .WithMany(p => p.Orders)
               .HasForeignKey((Model.Order p) => p.ItemId);

            typeBuilder
                .HasOne(p => p.Employee)
                .WithMany(p => p.Orders)
                .HasForeignKey((Model.Order p) => p.EmployeeId);

            typeBuilder
                .HasOne(p => p.Client)
                .WithMany(p => p.Orders)
                .HasForeignKey((Model.Order p) => p.ClientId);
        }
    }
}
