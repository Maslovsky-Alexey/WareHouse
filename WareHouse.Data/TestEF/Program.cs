using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEF
{
    class Program
    {
        public class Blad
        {
            public int Id { get; set; }
        }

        public class RabotaiBladDb : DbContext
        {
            public DbSet<Blad> Blads { get; set; }
        }

        static void Main(string[] args)
        {
            var db = new RabotaiBladDb();

            db.Blads.Add(new Blad());


            db.SaveChanges();
        }
    }
}
