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
    public class OrderService : BaseService<Domain.Model.Order, Data.Model.Order>, IOrderService
    {
        public OrderService(BaseRepository<Data.Model.Order> repository) : base(repository,
            new ModelsMapper<Data.Model.Order, Domain.Model.Order>(new OrderMapConfigurator()))
        {

        }
    }
}
