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
            //typeBuilder
            //    .HasOne(p => p.WarehouseItem)
            //    .WithOne(p => p.Status)
            //    .HasForeignKey<Model.WarehouseItem>(p => p.StatusId);

            typeBuilder
                .Property(x => x.Status)
                .HasDefaultValue(Status.UnknowItem);
        }
    }
}
