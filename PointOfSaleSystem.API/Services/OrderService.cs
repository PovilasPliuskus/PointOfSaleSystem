using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.Order;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void CreateOrder(Order order)
        {
            _orderRepository.Create(order);
        }

        public Order GetOrder(Guid id)
        {
            return _orderRepository.Get(id);
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        public void UpdateOrder(UpdateOrderRequest request)
        {
            _orderRepository.Update(request);
        }

        public void DeleteOrder(Guid id)
        {
            _orderRepository.Delete(id);
        }
    }
}
