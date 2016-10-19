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
using Order = WareHouse.Domain.Model.Order;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class OrderService : BaseService<Domain.Model.Order, Data.Model.Order>, IOrderService
    {
        private readonly IItemStatusService itemStatusService;
        private readonly IOrderRepository orderRepository;

        public OrderService(BaseRepository<Data.Model.Order> repository, IItemStatusService itemStatusService) : base(repository,
            new ModelsMapper<Data.Model.Order, Domain.Model.Order>(new OrderMapConfigurator()))
        {
            this.itemStatusService = itemStatusService;
            orderRepository = (IOrderRepository) repository;
        }

        public async Task UpdateOrderStatus(int id, int statusId)
        {
            await orderRepository.UpdateOrderStatus(id, statusId);
        }
    }
}
