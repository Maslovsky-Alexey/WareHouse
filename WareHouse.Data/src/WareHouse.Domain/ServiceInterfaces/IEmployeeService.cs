using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IEmployeeService : IService<Domain.Model.Employee, Data.Model.Employee>
    {
        Task<Model.Employee> GetEmployeeByName(string name, bool ignoreCase);

        Task<Model.Employee> GetEmployeeByIdentityId(string identityId);
    }
}
