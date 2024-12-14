using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.FullOrder;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface IFullOrderService
    {
        public void CreateFullOrder(FullOrder fullOrder);
        public FullOrder GetFullOrder(Guid id);
        public List<FullOrder> GetAllFullOrders();
        public void UpdateFullOrder(UpdateFullOrderRequest request);
        public void DeleteFullOrder(Guid id);
    }
}
