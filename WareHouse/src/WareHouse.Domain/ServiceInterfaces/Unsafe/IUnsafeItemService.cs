﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model.ViewModel;

namespace WareHouse.Domain.ServiceInterfaces.Unsafe
{
    public interface IUnsafeItemService : IUnsafeService<Item, Data.Model.Item>
    {
        Task AddWithoutRepetition(Item item);
    }
}
