﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.MyOData;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface ISupplyService : IService<Domain.Model.Supply, Data.Model.Supply>
    {

    }
}