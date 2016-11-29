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
        public EmployeeService(BaseRepository<Data.Model.Employee> repository, IMapConfigurator mapConfigurator) : base(repository,
            new ModelsMapper<Data.Model.Employee, Employee>(mapConfigurator))
        {
        }

        public async Task<Employee> AddOrAssignWithApplicationUser(string employeeName, string userId)
        {
            var employee = await GetEmployeeByName(employeeName, false);

            if (employee == null)
            {
                await Add(new Employee { Name = employeeName, UserId = userId });

                return await GetEmployeeByName(employeeName, false);
            }
            else
            {
                var result = MapToServiceModel(await ((EmployeeRepository)repository).AssignWithApplicationUser(employee.Id, userId));

                if (result != null)
                    OnNext(result);

                return result;
            }
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