using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WareHouse.Data.Model;

namespace WareHouse.Data.EF.Context.Mapping
{
    public class ProviderMapper : IMapper<Employee>
    {
        public void Map(EntityTypeBuilder<Employee> typeBuilder)
        {
            typeBuilder
                .Property(provider => provider.Name)
                .HasDefaultValue("Noname")
                .HasMaxLength(25);
        }
    }
}