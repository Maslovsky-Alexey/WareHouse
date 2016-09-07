using System;
using Microsoft.EntityFrameworkCore;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class EmployeeRepository : BaseService<Employee>, IEmployeeService
    {
        public EmployeeRepository(DbSet<Employee> employees) : base(employees)
        {
        }       
    }
}
