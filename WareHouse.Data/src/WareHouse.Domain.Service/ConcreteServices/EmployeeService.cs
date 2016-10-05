using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.Model;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class EmployeeService : BaseService<Domain.Model.Employee, Data.Model.Employee>, IEmployeeService
    {
        public EmployeeService(BaseRepository<Data.Model.Employee> repository) : base(repository, 
            new ModelsMapper<Data.Model.Employee, Domain.Model.Employee>(new EmployeeMapConfigurator()))
        {

        }

        public async Task<Employee> GetEmployeeByIdentityId(string identityId)
        {
            return MapToServiceModel((await ((EmployeeRepository)repository).GetEmployeeByIdentityId(identityId)));
        }

        public async Task<Employee> GetEmployeeByName(string name, bool ignoreCase)
        {
            return MapToServiceModel((await((EmployeeRepository)repository).GetEmployeeByName(name, ignoreCase)));
        }
    }
}
