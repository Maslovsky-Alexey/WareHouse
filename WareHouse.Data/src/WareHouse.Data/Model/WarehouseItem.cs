﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Data.Model
{
    public class WarehouseItem : BaseModel
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int StatusId { get; set; }
        public ItemStatus Status { get; set; }

        public int Count { get; set; }
    }
}