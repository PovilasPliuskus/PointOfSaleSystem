using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.EstablishmentProduct;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Services
{
    public class EstablishmentProductService : IEstablishmentProductService
    {
        private readonly IEstablishmentProductRepository _establishmentProductRepository;

        public EstablishmentProductService(IEstablishmentProductRepository establishmentProductRepository)
        {
            _establishmentProductRepository = establishmentProductRepository;
        }

        public void CreateEstablishmentProduct(AddEstablishmentProductRequest request)
        {
            _establishmentProductRepository.Create(request);
        }

        public EstablishmentProduct GetEstablishmentProduct(Guid id)
        {
            return _establishmentProductRepository.Get(id);
        }

        public List<EstablishmentProduct> GetAllEstablishmentProducts()
        {
            return _establishmentProductRepository.GetAll();
        }

        public void UpdateEstablishmentProduct(UpdateEstablishmentProductRequest request)
        {
            _establishmentProductRepository.Update(request);
        }

        public void DeleteEstablishmentProduct(Guid id)
        {
            _establishmentProductRepository.Delete(id);
        }
    }
}
