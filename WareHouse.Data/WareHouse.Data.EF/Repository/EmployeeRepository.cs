using System;
using Microsoft.EntityFrameworkCore;
using WareHouse.Data.Repository;
using WareHouse.Data.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using WareHouse.Data.EF.Context;

namespace WareHouse.Data.EF.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private WareHouseDbContext context;

        public EmployeeRepository(WareHouseDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await context.Employees.ToArrayAsync();
        }

        public async Task Add(Employee client)
        {
            await Task.Factory.StartNew(() => context.Employees.Add(client));
        }

        public async Task Remove(Employee client)
        {
            await Task.Factory.StartNew(() => context.Employees.Remove(client));
        }

        public async Task<Employee> GetItem(int id)
        {
            return await context.Employees.FirstAsync(employee => employee.ID == id);
        }

        public async Task<int> Count()
        {
            return await Task.Factory.StartNew(context.Employees.Count);
        }
    }
}
