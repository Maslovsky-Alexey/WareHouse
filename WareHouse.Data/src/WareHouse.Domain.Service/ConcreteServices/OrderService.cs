using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.ServiceInterfaces;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class OrderService : BaseService<Order, Data.Model.Order>, IOrderService
    {
        private readonly IItemStatusService itemStatusService;
        private readonly IOrderRepository orderRepository;

        public OrderService(BaseRepository<Data.Model.Order> repository, IItemStatusService itemStatusService)
            : base(repository,
                new ModelsMapper<Data.Model.Order, Order>(new OrderMapConfigurator()))
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