using System;
using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.ServiceInterfaces;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class EmployeeService : BaseService<Employee, Data.Model.Employee>, IEmployeeService
    {
        public EmployeeService(BaseRepository<Data.Model.Employee> repository) : base(repository,
            new ModelsMapper<Data.Model.Employee, Employee>(new EmployeeMapConfigurator()))
        {
        }

        public async Task<Employee> AssignWithApplicationUser(int employeeId, string userId)
        {
            return MapToServiceModel(await ((EmployeeRepository) repository).AssignWithApplicationUser(employeeId, userId));
        }

        public async Task<Employee> GetEmployeeByIdentityId(string identityId)
        {
            return MapToServiceModel(await ((EmployeeRepository) repository).GetEmployeeByIdentityId(identityId));
        }

        public async Task<Employee> GetEmployeeByName(string name, bool ignoreCase)
        {
            return MapToServiceModel(await ((EmployeeRepository) repository).GetEmployeeByName(name, ignoreCase));
        }
    }
}