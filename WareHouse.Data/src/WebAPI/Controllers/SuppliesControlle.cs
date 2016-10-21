using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.ServiceInterfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SuppliesController : Controller
    {
        private readonly ISupplyService items;

        public SuppliesController(ISupplyService items)
        {
            this.items = items;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<SupplyViewModel>> Get()
        {
            return await items.GetAllAsViewModel();
        }

        [Route("GetProviderSupplies/{providerName}")]
        [HttpGet("{providerName}")]
        public async Task<IEnumerable<SupplyViewModel>> GetProviderSupplies(string providerName)
        {
            return await items.GetProviderSupplies(providerName);
        }
    }
}