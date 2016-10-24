﻿using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.ServiceInterfaces.Unsafe;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IEmployeeService : IService<Employee, Data.Model.Employee>, ISafeEmployeeService, IUnsafeEmployeeService
    {

    }
}