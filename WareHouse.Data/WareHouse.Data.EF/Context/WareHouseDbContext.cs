using Microsoft.EntityFrameworkCore;
using WareHouse.Data.EF.Repository;
using WareHouse.Data.Model;

namespace WareHouse.Data.EF.Context
{
    public class WareHouseDbContext : DbContext
    {
        public ClientRepository Clients { get; set; }

        public ItemRepository Items { get; set; }

        public EmployeeRepository Employees { get; set; }

        public ProviderRepository Providers { get; set; }


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
