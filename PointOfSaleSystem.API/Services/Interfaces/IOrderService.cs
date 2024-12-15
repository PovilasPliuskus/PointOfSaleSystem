using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Order;
using PointOfSaleSystem.API.ResponseBodies.Order;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface IOrderService
    {
        public void CreateOrder(AddOrderRequest order);
        public GetOrderResponse GetOrder(Guid id);
        public List<GetOrderResponse> GetAllOrders();
        public void UpdateOrder(UpdateOrderRequest request);
        public void DeleteOrder(Guid id);
    }
}
