using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.EstablishmentProduct;

namespace PointOfSaleSystem.API.Repositories.Interfaces
{
    public interface IEstablishmentProductRepository
    {
        public void Create(AddEstablishmentProductRequest request);
        public EstablishmentProduct Get(Guid id);
        public List<EstablishmentProduct> GetAll();
        public void Update(UpdateEstablishmentProductRequest request);
        public void Delete(Guid id);
    }
}
