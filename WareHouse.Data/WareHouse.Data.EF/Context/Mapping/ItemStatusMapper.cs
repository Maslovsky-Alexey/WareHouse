using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.Model;

namespace WareHouse.Data.EF.Context.Mapping
{
    public class ItemStatusMapper : IMapper<ItemStatus>
    {
        public void Map(EntityTypeBuilder<ItemStatus> typeBuilder)
        {
            typeBuilder
                .Property(status => status.Name)
                .HasDefaultValue("Noname")
                .HasMaxLength(50);
        }
    }
}
