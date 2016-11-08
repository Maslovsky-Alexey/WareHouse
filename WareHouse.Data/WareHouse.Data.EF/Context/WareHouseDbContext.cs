using Microsoft.EntityFrameworkCore;
using WareHouse.Data.EF.Context.Mapping;
using WareHouse.Data.EF.Repository;
using WareHouse.Data.Model;
using System;

namespace WareHouse.Data.EF.Context
{
    public class WareHouseDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Provider> Providers { get; set; }

        public DbSet<ItemStatus> ItemStatus { get; set; }

        public DbSet<WarehouseItem> WarehouseItem { get; set; }


        public WareHouseDbContext(DbContextOptions<WareHouseDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();

            if (Database.EnsureCreated())
            {
                Seed();
            }
        }


        private void Seed()
        {
            foreach (string name in Enum.GetNames(typeof(Status)))
            {
                ItemStatus.Add(new ItemStatus() {
                    Name = name,
                    Status = (Status)Enum.Parse(typeof(Status), name)
                });
            }
       
            SaveChanges();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Mapper.MapModels(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
