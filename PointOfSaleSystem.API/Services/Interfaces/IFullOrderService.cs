using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.FullOrder;
using PointOfSaleSystem.API.ResponseBodies.FullOrder;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface IFullOrderService
    {
        public void CreateFullOrder(FullOrder fullOrder);
        public GetFullOrderResponse GetFullOrder(Guid id);
        public List<GetFullOrderResponse> GetAllFullOrders();
        public void UpdateFullOrder(UpdateFullOrderRequest request);
        public void DeleteFullOrder(Guid id);
    }
}
