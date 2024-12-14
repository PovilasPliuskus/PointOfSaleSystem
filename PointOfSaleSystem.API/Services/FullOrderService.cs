using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.FullOrder;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Services
{
    public class FullOrderService : IFullOrderService
    {
        private readonly IFullOrderRepository _fullOrderRepository;

        public FullOrderService(IFullOrderRepository fullOrderRepository)
        {
            _fullOrderRepository = fullOrderRepository;
        }

        public void CreateFullOrder(FullOrder fullOrder)
        {
            _fullOrderRepository.Create(fullOrder);
        }

        public FullOrder GetFullOrder(Guid id)
        {
            return _fullOrderRepository.Get(id);
        }

        public List<FullOrder> GetAllFullOrders()
        {
            return _fullOrderRepository.GetAll();
        }

        public void UpdateFullOrder(UpdateFullOrderRequest request)
        {
            _fullOrderRepository.Update(request);
        }

        public void DeleteFullOrder(Guid id)
        {
            _fullOrderRepository.Delete(id);
        }
    }
}
