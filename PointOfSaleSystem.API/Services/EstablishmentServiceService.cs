using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.EstablishmentService;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Services
{
    public class EstablishmentServiceService : IEstablishmentServiceService
    {
        private readonly IEstablishmentServiceRepository _establishmentServiceRepository;

        public EstablishmentServiceService(IEstablishmentServiceRepository establishmentServiceRepository)
        {
            _establishmentServiceRepository = establishmentServiceRepository;
        }

        public void CreateEstablishmentService(AddEstablishmentServiceRequest request)
        {
            _establishmentServiceRepository.Create(request);
        }

        public Models.EstablishmentService GetEstablishmentService(Guid id)
        {
            return _establishmentServiceRepository.Get(id);
        }

        public List<Models.EstablishmentService> GetAllEstablishmnentServices()
        {
            return _establishmentServiceRepository.GetAll();
        }

        public void UpdateEstablishmentService(UpdateEstablishmentServiceRequest request)
        {
            _establishmentServiceRepository.Update(request);
        }

        public void DeleteEstablishmentService(Guid id)
        {
            _establishmentServiceRepository.Delete(id);
        }
    }
}
