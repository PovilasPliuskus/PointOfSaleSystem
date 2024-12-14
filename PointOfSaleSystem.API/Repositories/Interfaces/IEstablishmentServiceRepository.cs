using PointOfSaleSystem.API.Models;

namespace PointOfSaleSystem.API.Repositories.Interfaces
{
    public interface IEstablishmentServiceRepository
    {
        public List<EstablishmentService> GetAll();
    }
}
