using WareHouse.Data.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace WareHouse.Data.EF.Context.Mapping
{
    public class ClientMapper : IMapper<Client>
    {
        public void Map(EntityTypeBuilder<Client> typeBuilder)
        {
            typeBuilder
                .HasOne(p => p.User)
                .WithOne()
                .HasForeignKey<Client>(p => p.UserId);
        }
    }
}
