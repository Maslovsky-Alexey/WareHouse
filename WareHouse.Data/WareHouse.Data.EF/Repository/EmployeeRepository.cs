using System;
using Microsoft.EntityFrameworkCore;
using WareHouse.Data.Repository;
using WareHouse.Data.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WareHouse.Data.EF.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private DbSet<Employee> employees;

        public EmployeeRepository(DbContext context)
        {
            employees = context.Set<Employee>();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await employees.ToArrayAsync();
        }

        public async Task Add(Employee client)
        {
            await Task.Factory.StartNew(() => employees.Add(client));
        }

        public async Task Remove(Employee client)
        {
            await Task.Factory.StartNew(() => employees.Remove(client));
        }

        public async Task<Employee> GetItem(int id)
        {
            return await employees.FirstAsync(employee => employee.ID == id);
        }

        public async Task<int> Count()
        {
            return await Task.Factory.StartNew(employees.Count);
        }
    }
}
