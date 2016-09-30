﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.Model;

namespace WareHouse.Data.Repository
{
    public interface IItemStatusRepository : IRepository<Model.ItemStatus>
    {
        Task<ItemStatus> GetStatus(Status status);
    }
}
