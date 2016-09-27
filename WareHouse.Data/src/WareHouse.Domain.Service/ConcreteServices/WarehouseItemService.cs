using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.ServiceInterfaces;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class WarehouseItemService : BaseService<Domain.Model.WarehouseItem, Data.Model.WarehouseItem>, IWarehouseItemService
    {
        public WarehouseItemService(BaseRepository<Data.Model.WarehouseItem> repository) : base(repository, 
            new ModelsMapper<Data.Model.WarehouseItem, Domain.Model.WarehouseItem>(new WarehouseItemMapConfigurator()))
        {

        }
    }
}
