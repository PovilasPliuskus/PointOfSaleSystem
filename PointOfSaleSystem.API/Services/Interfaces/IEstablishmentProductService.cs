using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.EstablishmentProduct;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface IEstablishmentProductService
    {
        public void CreateEstablishmentProduct(AddEstablishmentProductRequest request);
        public EstablishmentProduct GetEstablishmentProduct(Guid id);
        public List<EstablishmentProduct> GetAllEstablishmentProducts();
        public void UpdateEstablishmentProduct(UpdateEstablishmentProductRequest request);
        public void DeleteEstablishmentProduct(Guid id);
    }
}
