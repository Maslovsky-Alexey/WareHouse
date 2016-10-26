using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.ServiceInterfaces.Unsafe;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SuppliesController : Controller
    {
        private readonly ISafeSupplyService safeSupplyService;
        private readonly IUnsafeSupplyService unsafeSupplyService;

        public SuppliesController(ISafeSupplyService safeSupplyService, IUnsafeSupplyService unsafeSupplyService)
        {
            this.safeSupplyService = safeSupplyService;
            this.unsafeSupplyService = unsafeSupplyService;
        }

        // GET: api/values
        [HttpGet]
        [Authorize(Roles = "employee")]
        public async Task<IEnumerable<SupplyViewModel>> Get()
        {
            return await safeSupplyService.GetAllAsViewModel();
        }

        [Route("GetProviderSupplies/{providerName}")]
        [HttpGet("{providerName}")]
        [Authorize(Roles = "employee")]
        public async Task<IEnumerable<SupplyViewModel>> GetProviderSupplies(string providerName)
        {
            return await safeSupplyService.GetProviderSupplies(providerName);
        }
    }
}