using Microsoft.EntityFrameworkCore;
using WareHouse.Data.EF.Context.Mapping;
using WareHouse.Data.EF.Repository;
using WareHouse.Data.Model;



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


        public WareHouseDbContext(): base()
        {

        }

        public WareHouseDbContext(DbContextOptions option) : base(option)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();         
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Mapper.MapModels(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
