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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasKey(client => client.ID);

            modelBuilder.Entity<Provider>()
                 .HasKey(provider => provider.ID);

            modelBuilder.Entity<Item>()
                .HasKey(item => item.ID);

            modelBuilder.Entity<Employee>()
                 .HasKey(employee => employee.ID);
       }
    }
}
