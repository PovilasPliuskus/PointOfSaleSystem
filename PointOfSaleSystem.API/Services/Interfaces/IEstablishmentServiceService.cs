using PointOfSaleSystem.API.RequestBodies.EstablishmentService;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface IEstablishmentServiceService
    {
        public void CreateEstablishmentService(AddEstablishmentServiceRequest request);
        public Models.EstablishmentService GetEstablishmentService(Guid id);
        public List<Models.EstablishmentService> GetAllEstablishmnentServices();
        public void UpdateEstablishmentService(UpdateEstablishmentServiceRequest request);
        public void DeleteEstablishmentService(Guid id);
    }
}
