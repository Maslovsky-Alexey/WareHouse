using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class ProviderService : BaseService<Domain.Model.Provider, Data.Model.Provider>
    {
        public ProviderService(BaseRepository<Data.Model.Provider> repository) : base(repository)
        {

        }

        protected override Data.Model.Provider MapToEFModel(Domain.Model.Provider model)
        {
            return new ModelsMapper.ProviderMapper().MapEF(model);
        }

        protected override Domain.Model.Provider MapToServiceModel(Data.Model.Provider model)
        {
            return new ModelsMapper.ProviderMapper().MapService(model);
        }
    }
}
