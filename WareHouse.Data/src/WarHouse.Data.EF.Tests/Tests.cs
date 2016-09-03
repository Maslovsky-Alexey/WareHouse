using Xunit;
using WareHouse.Data.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WareHouse.Data.Model;
using WareHouse.Data.EF.Repository;
using System.Linq;

namespace WarHouse.Data.EF.Tests
{
    
    public class Tests
    {
        private DbContextOptions contextOption;

        public Tests()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<WareHouseDbContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            contextOption = builder.Options;

            Seed();
        }

        private void Seed()
        {
            using (var context = new WareHouseDbContext(contextOption))
            {
                context.Clients.Add(new Client { Name = "Ivan" });
                context.Clients.Add(new Client { Name = "Sergey" });
                context.Clients.Add(new Client { Name = "Alexey" });
                context.SaveChanges();
            }
        }

        [Fact]
        public void CheckBeginCountClient()
        {
            using (var context = new WareHouseDbContext(contextOption))
            {
                Assert.Equal(context.Clients.Count(), 3);
            }
        }

        [Fact]
        public async void AddClientTest()
        {
            int beginCount;

            using (var context = new WareHouseDbContext(contextOption))
            {
                var clientRepository = new ClientRepository(context);

                beginCount = context.Clients.Count();

                await clientRepository.Add(new Client() { Name = "Petr" });
                context.SaveChanges();
            }


            using (var context = new WareHouseDbContext(contextOption))
            {
                Assert.Equal(context.Clients.Count(), beginCount + 1);
            }
        }

        [Fact]
        public async void RemoveClientTest()
        {
            int beginCount;

            using (var context = new WareHouseDbContext(contextOption))
            {
                var clientRepository = new ClientRepository(context);

                beginCount = context.Clients.Count();

                var removingClient = context.Clients.First(client => client.Name == "Alexey");

                await clientRepository.Remove(removingClient);
                context.SaveChanges();
            }


            using (var context = new WareHouseDbContext(contextOption))
            {
                Assert.Equal(context.Clients.Count(), beginCount - 1);
            }
        }

        [Fact]
        public async void TestGetClient()
        {
            using (var context = new WareHouseDbContext(contextOption))
            {
                var clientRepository = new ClientRepository(context);

                var firtsClient = await clientRepository.GetItem(1);

                Assert.Equal(firtsClient.Name, "Ivan");
            }
        }
    }
}
