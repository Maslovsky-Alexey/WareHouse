using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.Service.ConcreteServices;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.ServiceInterfaces.Safe;

namespace WareHouse.Domain.Service.ProxyServices
{
    public class EmployeeProxyService : ISafeEmployeeService
    {
        private ISafeEmployeeService safeEmployeeService;


        public EmployeeProxyService(ISafeEmployeeService safeEmployeeService)
        {
            this.safeEmployeeService = safeEmployeeService;
        }

        public async Task<int> Count()
        {
            return await safeEmployeeService.Count();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await safeEmployeeService.GetAll();
        }

        public async Task<Employee> GetEmployeeByIdentityId(string identityId)
        {
            return await safeEmployeeService.GetEmployeeByIdentityId(identityId);
        }

        public async Task<Employee> GetEmployeeByName(string name, bool ignoreCase)
        {
            return await safeEmployeeService.GetEmployeeByName(name, ignoreCase);
        }

        public async Task<Employee> GetItem(int id)
        {
            return await safeEmployeeService.GetItem(id);
        }

    }
}
