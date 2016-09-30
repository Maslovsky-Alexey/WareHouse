using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WareHouse.Data.Model
{
    public class ApplicationUser : IdentityUser
    {
        public Employee Employee { get; set; }

        public Client Client { get; set; }
    }
}
