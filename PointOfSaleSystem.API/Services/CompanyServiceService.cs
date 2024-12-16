using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.CompanyService;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Services
{
    public class CompanyServiceService : ICompanyServiceService
    {
        private readonly ICompanyServiceRepository _companyServiceRepository;

        public CompanyServiceService(ICompanyServiceRepository companyServiceRepository)
        {
            _companyServiceRepository = companyServiceRepository;
        }

        public void CreateCompanyService(AddCompanyServiceRequest request)
        {
            _companyServiceRepository.Create(request);
        }

        public Models.CompanyService GetCompanyService(Guid id)
        {
            return _companyServiceRepository.Get(id);
        }

        public List<Models.CompanyService> GetCompanyServices()
        {
            return _companyServiceRepository.GetAll();
        }

        public void UpdateCompanyService(UpdateCompanyServiceRequest request)
        {
            _companyServiceRepository.Update(request);
        }

        public void DeleteCompanyService(Guid id)
        {
            _companyServiceRepository.Delete(id);
        }
    }
}
