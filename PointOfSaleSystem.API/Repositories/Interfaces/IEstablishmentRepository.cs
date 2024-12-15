using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Establishment;

namespace PointOfSaleSystem.API.Repositories.Interfaces
{
    public interface IEstablishmentRepository
    {
        public void Create(AddEstablishmentRequest establishment);
        public Establishment Get(Guid id);
        public List<Establishment> GetAll();
        public void Update(UpdateEstablishmentRequest request);
        public void Delete(Guid id);
    }
}