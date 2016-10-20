using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WareHouse.Data.Model;

namespace WareHouse.Data.EF.Context.Mapping
{
    public class ApplicationUserMapper : IMapper<ApplicationUser>
    {
        public void Map(EntityTypeBuilder<ApplicationUser> typeBuilder)
        {
        }
    }
}