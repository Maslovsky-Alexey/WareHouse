using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouse.AutharizationAPI.Context;
using Microsoft.EntityFrameworkCore;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WareHouse.AutharizationAPI.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public string AA()
        {
            try
            {
                var connection = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=AuthDb;Integrated Security=True";
                var builder = new DbContextOptionsBuilder<UsersContext>().UseSqlServer(connection);

                new UsersContext(builder.Options);

                return "OK";
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
    }
}
