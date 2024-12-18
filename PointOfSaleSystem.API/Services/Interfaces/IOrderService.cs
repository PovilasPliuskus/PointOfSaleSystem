using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Order;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.ResponseBodies.Order;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface IOrderService
    {
        public void CreateOrder(AddOrderRequest order, UserInfo userInfo);
        public GetOrderResponse GetOrder(Guid id, UserInfo userInfo);
        public List<GetOrderResponse> GetAllOrders(UserInfo userInfo);
        public void UpdateOrder(UpdateOrderRequest request, UserInfo userInfo);
        public void DeleteOrder(Guid id, UserInfo userInfo);
    }
}
