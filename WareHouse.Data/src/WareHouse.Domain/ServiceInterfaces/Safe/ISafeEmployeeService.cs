using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;

namespace WareHouse.Domain.ServiceInterfaces.Safe
{
    public interface ISafeEmployeeService
    {
        Task<Employee> GetEmployeeByName(string name, bool ignoreCase);

        Task<Employee> GetEmployeeByIdentityId(string identityId);
    }
}
