using System.Threading.Tasks;
using WareHouse.Domain.Model;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IEmployeeService : IService<Employee, Data.Model.Employee>
    {
        Task<Employee> GetEmployeeByName(string name, bool ignoreCase);

        Task<Employee> GetEmployeeByIdentityId(string identityId);
    }
}