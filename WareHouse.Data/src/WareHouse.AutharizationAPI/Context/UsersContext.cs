using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.AutharizationAPI.Context.Models;

namespace WareHouse.AutharizationAPI.Context
{
    public class UsersContext : IdentityDbContext<ApplicationUser>
    {
        public UsersContext(DbContextOptions<UsersContext> options)
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
            Roles.Add(new IdentityRole("employee") { NormalizedName = "EMPLOYEE" });
            Roles.Add(new IdentityRole("client") { NormalizedName = "CLIENT" });

            
            SaveChanges();
        }
    }
}
