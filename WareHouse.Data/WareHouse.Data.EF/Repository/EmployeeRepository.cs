using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WareHouse.Data.EF.Context;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;

namespace WareHouse.Data.EF.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(WareHouseDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Employee> GetEmployeeByIdentityId(string identityId)
        {
            return await context.Employees.FirstOrDefaultAsync(x => x.UserId == identityId);
        }

        public async Task<Employee> GetEmployeeByName(string name, bool ignoreCase)
        {
            if (ignoreCase)
                return await context.Employees.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            return await context.Employees.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}