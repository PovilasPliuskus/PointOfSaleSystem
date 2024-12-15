using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Establishment;

namespace PointOfSaleSystem.API.Repositories.Interfaces
{
    public interface IEstablishmentRepository
    {
        void Create(Establishment establishment);
        Establishment Get(Guid id);
        List<Establishment> GetAll();
        void Update(UpdateEstablishmentRequest request);
        void Delete(Guid id);
    }
}