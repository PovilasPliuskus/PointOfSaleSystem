using PointOfSaleSystem.API.Models;

namespace PointOfSaleSystem.API.Repositories.Interfaces
{
    public interface IEstablishmentProductRepository
    {
        public List<EstablishmentProduct> GetAll();
    }
}
