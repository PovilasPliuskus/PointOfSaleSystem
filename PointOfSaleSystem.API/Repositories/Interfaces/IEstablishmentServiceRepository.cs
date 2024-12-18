using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.EstablishmentService;

namespace PointOfSaleSystem.API.Repositories.Interfaces
{
    public interface IEstablishmentServiceRepository
    {
        public void Create(AddEstablishmentServiceRequest request);
        public EstablishmentService Get(Guid id);
        public List<EstablishmentService> GetAll();
        public void Update(UpdateEstablishmentServiceRequest request);
        public void Delete(Guid id);
        public List<EstablishmentService> GetAllByEmployeeId(Guid employeeId);
        public List<EstablishmentService> GetEstablishmentServiceByEmployeeId(Guid employeeId);
    }
}
