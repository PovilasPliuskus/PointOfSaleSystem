using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Order;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface IOrderService
    {
        public void CreateOrder(Order order);
        public Order GetOrder(Guid id);
        public List<Order> GetAllOrders();
        public void UpdateOrder(UpdateOrderRequest request);
        public void DeleteOrder(Guid id);
    }
}
