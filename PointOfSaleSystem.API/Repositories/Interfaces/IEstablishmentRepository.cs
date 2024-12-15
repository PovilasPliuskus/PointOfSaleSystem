using PointOfSaleSystem.API.Models;

namespace PointOfSaleSystem.API.Repositories.Interfaces
{
    public interface IEstablishmentRepository
    {
        public Establishment Get(Guid id);
        public List<Establishment> GetlAll();
    }
}
