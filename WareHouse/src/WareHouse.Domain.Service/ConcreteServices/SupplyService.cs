using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.ServiceInterfaces;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class SupplyService : BaseService<Supply, Data.Model.Supply>, ISupplyService
    {
        private readonly ISupplyRepository supplyRepository;

        public SupplyService(BaseRepository<Data.Model.Supply> repository, IMapConfigurator mapConfigurator) : base(repository,
            new ModelsMapper<Data.Model.Supply, Supply>(mapConfigurator))
        {
            supplyRepository = (ISupplyRepository) repository;
        }

        public async Task<IEnumerable<SupplyViewModel>> GetAllAsViewModel()
        {
            return (await GetAll())
                .Select(ToViewModel);
        }

        public async Task UpdateSupplyStatus(int id, int statusId)
        {
            await supplyRepository.UpdateSupplyStatus(id, statusId);
            OnNext(null);
        }

        public async Task<IEnumerable<SupplyViewModel>> GetProviderSupplies(string providerName)
        {
            return (await GetAll())
                .Where(x => x.Provider.Name == providerName)
                .Select(ToViewModel);
        }

        private SupplyViewModel ToViewModel(Supply supply)
        {
            return new SupplyViewModel
            {
                Id = supply.Id,
                Item = supply.Item,
                Status = supply.Status,
                Provider = supply.Provider,
                Employee = supply.Employee,
                Count = supply.Count,
                DateTime = supply.DateTime.ToString("dd MMMM yyyy HH:mm:ss")
            };
        }
    }
}