using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.Model;
using WareHouse.MyOData;
using System.Linq.Expressions;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class SupplyService : BaseService<Domain.Model.Supply, Data.Model.Supply>, ISupplyService
    {
        public SupplyService(BaseRepository<Data.Model.Supply> repository) : base(repository,
            new ModelsMapper<Data.Model.Supply, Domain.Model.Supply>(new SupplyMapConfigurator()))
        {

        }
    }
}
