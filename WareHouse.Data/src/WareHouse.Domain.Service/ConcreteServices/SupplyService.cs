using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.MyOData;
using System.Linq.Expressions;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model.ViewModel;
using Supply = WareHouse.Domain.Model.Supply;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class SupplyService : BaseService<Domain.Model.Supply, Data.Model.Supply>, ISupplyService
    {
        private readonly ISupplyRepository supplyRepository;

        public SupplyService(BaseRepository<Data.Model.Supply> repository) : base(repository,
            new ModelsMapper<Data.Model.Supply, Domain.Model.Supply>(new SupplyMapConfigurator()))
        {
            supplyRepository = (ISupplyRepository) repository;
        }

        public async Task UpdateSupplyStatus(int id, int statusId)
        {
            await supplyRepository.UpdateSupplyStatus(id, statusId);
        }
    }
}
