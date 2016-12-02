using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.FileCheckerService.Context
{
    public class HistoryDbContext : DbContext
    {
        public DbSet<Models.ChangeModel> Changes { get; set; }

        public HistoryDbContext() : base("History")
        {
            Database.CreateIfNotExists();
        }
    }
}
