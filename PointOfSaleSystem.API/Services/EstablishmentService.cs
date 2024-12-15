using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.Establishment;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Services
{
    public class EstablishmentService : IEstablishmentService
    {
        private readonly IEstablishmentRepository _establishmentRepository;

        public EstablishmentService(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }

        public void CreateEstablishment(Establishment establishment)
        {
            _establishmentRepository.Create(establishment);
        }

        public Establishment GetEstablishment(Guid id)
        {
            return _establishmentRepository.Get(id);
        }

        public List<Establishment> GetAllEstablishments()
        {
            return _establishmentRepository.GetAll();
        }

        public void UpdateEstablishment(UpdateEstablishmentRequest request)
        {
            _establishmentRepository.Update(request);
        }

        public void DeleteEstablishment(Guid id)
        {
            _establishmentRepository.Delete(id);
        }
    }
}