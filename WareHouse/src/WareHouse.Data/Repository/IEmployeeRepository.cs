using System.Threading.Tasks;
using WareHouse.Data.Model;

namespace WareHouse.Data.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> GetEmployeeByName(string name, bool ignoreCase);

        Task<Employee> GetEmployeeByIdentityId(string identityId);

        Task<Employee> AssignWithApplicationUser(int employeeId, string userId);
    }
}