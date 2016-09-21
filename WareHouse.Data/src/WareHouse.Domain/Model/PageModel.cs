using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model;

namespace WareHouse.Domain.Model
{
    public class PageModel
    {
        public IEnumerable<Item> Items { get; set; }

        public int NextPage { get; set; }

        public int PrevPage { get; set; }
    }
}
