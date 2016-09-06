using Microsoft.EntityFrameworkCore;
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

        public WareHouseDbContext(): base()
        {

        }

        public WareHouseDbContext(DbContextOptions option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
