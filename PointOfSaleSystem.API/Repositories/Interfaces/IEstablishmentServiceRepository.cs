using PointOfSaleSystem.API.Models;

namespace PointOfSaleSystem.API.Repositories.Interfaces
{
    public interface IEstablishmentServiceRepository
    {
        public EstablishmentService Get(Guid id);
        public List<EstablishmentService> GetAll();
    }
}
