using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WareHouse.Domain.Model;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.ServiceInterfaces.Unsafe;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly ISafeEmployeeService safeEmployeeService;
        private readonly IUnsafeEmployeeService usafeEmployeeService;

        public EmployeesController(ISafeEmployeeService safeEmployeeService, IUnsafeEmployeeService usafeEmployeeService)
        {
            this.safeEmployeeService = safeEmployeeService;
            this.usafeEmployeeService = usafeEmployeeService;
        }

        [HttpGet("{name}")]
        [Authorize(Roles = "employee")]
        public async Task<Employee> Get(string name)
        {
            var employee = await safeEmployeeService.GetEmployeeByName(name, true);

            if (employee == null)
            {
                NotFound();
                return null;
            }

            return employee;
        }
    }
}