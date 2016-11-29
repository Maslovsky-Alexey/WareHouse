using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model.ViewModel;

namespace WareHouse.Domain.ServiceInterfaces.Unsafe
{
    public interface IUnsafeEmployeeService : IUnsafeService<Employee, Data.Model.Employee>
    {
        Task<Employee> AddOrAssignWithApplicationUser(string employeeName, string userId);
    }
}
