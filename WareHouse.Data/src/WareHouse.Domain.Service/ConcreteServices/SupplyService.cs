using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.ServiceInterfaces;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class SupplyService : BaseService<Supply, Data.Model.Supply>, ISupplyService
    {
        private readonly ISupplyRepository supplyRepository;

        public SupplyService(BaseRepository<Data.Model.Supply> repository) : base(repository,
            new ModelsMapper<Data.Model.Supply, Supply>(new SupplyMapConfigurator()))
        {
            supplyRepository = (ISupplyRepository) repository;
        }

        public async Task UpdateSupplyStatus(int id, int statusId)
        {
            await supplyRepository.UpdateSupplyStatus(id, statusId);
        }
    }
}