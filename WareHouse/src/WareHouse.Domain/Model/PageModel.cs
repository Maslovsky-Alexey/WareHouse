﻿using System.Collections.Generic;
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