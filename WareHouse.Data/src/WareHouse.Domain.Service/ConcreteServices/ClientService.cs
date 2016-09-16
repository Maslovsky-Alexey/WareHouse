using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Context;
using WareHouse.Data.EF.Context.Mapping;
using WareHouse.Data.EF.Repository;
using WareHouse.Data.Model;
using WareHouse.Domain.Model;
using WareHouse.Domain.ServiceInterfaces;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class ClientService : BaseService<Domain.Model.Client, Data.Model.Client>
    {
        public ClientService(BaseRepository<Data.Model.Client> repository) : base(repository)
        {

        }

        protected override Data.Model.Client MapToEFModel(Model.Client model)
        {
            return new ModelsMapper.ClientMapper().MapEF(model);
        }

        protected override Model.Client MapToServiceModel(Data.Model.Client model)
        {
            return new ModelsMapper.ClientMapper().MapService(model);
        }

        public async Task<Model.Client> GetItemByName(string name)
        {
            return MapToServiceModel(await ((ClientRepository)repository).GetClientByName(name));
        }

        public async Task<Model.Client> GetItemByNameIgnoreCase(string name)
        {
            return MapToServiceModel(await ((ClientRepository)repository).GetClientByNameIgnoreCase(name));
        }
    }
}
