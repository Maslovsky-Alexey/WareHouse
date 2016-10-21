using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface ISupplyService : IService<Supply, Data.Model.Supply>
    {
        Task UpdateSupplyStatus(int id, int statusId);

        Task<IEnumerable<SupplyViewModel>> GetProviderSupplies(string providerName);

        Task<IEnumerable<SupplyViewModel>> GetAllAsViewModel();
    }
}