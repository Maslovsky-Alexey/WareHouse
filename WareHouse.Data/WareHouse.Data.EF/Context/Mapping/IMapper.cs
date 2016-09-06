using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WareHouse.Data.EF.Context.Mapping
{
    public interface IMapper<T> where T : class
    {
        void Map(EntityTypeBuilder<T> typeBuilder);
    }
}
