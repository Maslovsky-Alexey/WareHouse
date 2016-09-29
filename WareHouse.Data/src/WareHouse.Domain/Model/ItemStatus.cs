﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Domain.Model
{
    public class ItemStatus : BaseModel
    {
        public string Name { get; set; }

        public WarehouseItem WarehouseItem { get; set; }
    }
}
