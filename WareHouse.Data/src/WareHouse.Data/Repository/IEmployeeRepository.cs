using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.Model;

namespace WareHouse.Data.Repository
{
    public interface IEmployeeRepository : IRepository<Model.Employee>
    {
        Task<Employee> GetEmployeeByName(string name, bool ignoreCase);

        Task<Employee> GetEmployeeByIdentityId(string identityId);
    }
}
