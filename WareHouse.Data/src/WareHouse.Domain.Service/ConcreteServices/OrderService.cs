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
    public class OrderService : BaseService<Order, Data.Model.Order>, IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(BaseRepository<Data.Model.Order> repository)
            : base(repository,
                new ModelsMapper<Data.Model.Order, Order>(new OrderMapConfigurator()))
        {
            orderRepository = (IOrderRepository) repository;
        }

        public async Task<IEnumerable<OrderViewModel>> GetAllAsViewModel()
        {
            return (await GetAll())
                .Select(ToViewModel);
        }

        public async Task UpdateOrderStatus(int id, int statusId)
        {
            await orderRepository.UpdateOrderStatus(id, statusId);
            OnNext(null);
        }

        public async Task<IEnumerable<OrderViewModel>> GetClientOrders(string clientName)
        {
            return (await GetAll())
                .Where(x => x.Client.Name == clientName)
                .Select(ToViewModel);
        }

        private OrderViewModel ToViewModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                Item = order.Item,
                Status = order.Status,
                Client = order.Client,
                Employee = order.Employee,
                Count = order.Count,
                DateTime = order.DateTime.ToString("dd MMMM yyyy HH:mm:ss")
            };
        }
    }
}