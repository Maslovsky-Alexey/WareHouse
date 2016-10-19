using WareHouse.Data.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace WareHouse.Data.EF.Context.Mapping
{
    public class ApplicationUserMapper : IMapper<ApplicationUser>
    {
        public void Map(EntityTypeBuilder<ApplicationUser> typeBuilder)
        {

        }
    }
}
