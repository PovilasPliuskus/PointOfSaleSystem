using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.FullOrder;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.ResponseBodies.FullOrder;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface IFullOrderService
    {
        public void CreateFullOrder(FullOrder fullOrder, UserInfo userInfo);
        public GetFullOrderResponse GetFullOrder(Guid id, UserInfo userInfo);
        public List<GetFullOrderResponse> GetAllFullOrders(UserInfo userInfo);
        public void UpdateFullOrder(UpdateFullOrderRequest request, UserInfo userInfo);
        public void DeleteFullOrder(Guid id, UserInfo userInfo);
        public void RefundFullOrder(Guid id, UserInfo userInfo);
    }
}
