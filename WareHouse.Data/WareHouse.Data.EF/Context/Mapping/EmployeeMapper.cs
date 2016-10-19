using WareHouse.Data.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace WareHouse.Data.EF.Context.Mapping
{
    public class EmployeeMapper : IMapper<Employee>
    {
        public void Map(EntityTypeBuilder<Employee> typeBuilder)
        {
            typeBuilder
                .HasOne(p => p.User)
                .WithOne()
                .HasForeignKey<Employee>(p => p.UserId);

        }
    }
}
