using WareHouse.Data.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace WareHouse.Data.EF.Context.Mapping
{
    public class ItemMapper : IMapper<Employee>
    {
        public void Map(EntityTypeBuilder<Employee> typeBuilder)
        {
            typeBuilder
                .Property(item => item.Name)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}
