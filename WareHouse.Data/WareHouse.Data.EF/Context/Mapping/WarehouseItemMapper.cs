using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Data.EF.Context.Mapping
{
    public class WarehouseItemMapper : IMapper<Model.WarehouseItem>
    {
        public void Map(EntityTypeBuilder<Model.WarehouseItem> typeBuilder)
        {
            typeBuilder
                .HasOne(p => p.Item)
                .WithMany(p => p.WarehouseItems)
                .HasForeignKey((Model.WarehouseItem p) => p.ItemId);

            typeBuilder
                .HasOne(p => p.Status)
                .WithMany(p => p.WarehouseItems)
                .HasForeignKey((Model.WarehouseItem p) => p.StatusId);
        }
    }
}
