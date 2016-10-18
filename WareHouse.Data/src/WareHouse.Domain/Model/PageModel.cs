using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;

namespace WareHouse.Domain.Model
{
    public class PageModel
    {
        public IEnumerable<WarehouseItemViewModel> Items { get; set; }

        public int NextPage { get; set; }

        public int PrevPage { get; set; }

        public int Max { get; set; }

        public int Min { get; set; }
    }
}
