using PointOfSaleSystem.API.Models;

namespace PointOfSaleSystem.API.Repositories.Interfaces
{
    public interface IEstablishmentProductRepository
    {
        public EstablishmentProduct Get(Guid id);
        public List<EstablishmentProduct> GetAll();
    }
}
