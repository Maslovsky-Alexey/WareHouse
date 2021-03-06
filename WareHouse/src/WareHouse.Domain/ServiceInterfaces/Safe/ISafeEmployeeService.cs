﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;

namespace WareHouse.Domain.ServiceInterfaces.Safe
{
    public interface ISafeEmployeeService : ISafeService<Employee, Data.Model.Employee>
    {
        Task<Employee> GetEmployeeByName(string name, bool ignoreCase);

        Task<Employee> GetEmployeeByIdentityId(string identityId);
    }
}
