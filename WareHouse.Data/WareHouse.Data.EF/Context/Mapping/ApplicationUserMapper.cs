using WareHouse.Data.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace WareHouse.Data.EF.Context.Mapping
{
    public class ApplicationUserMapper : IMapper<ApplicationUser>
    {
        public void Map(EntityTypeBuilder<ApplicationUser> typeBuilder)
        {
            typeBuilder
                .HasOne(p => p.Client)
                .WithOne(p => p.User)
                .HasForeignKey<Model.Client>(p => p.UserId);

            typeBuilder
                .HasOne(p => p.Employee)
                .WithOne(p => p.User)
                .HasForeignKey<Model.Employee>(p => p.UserId);
        }
    }
}
