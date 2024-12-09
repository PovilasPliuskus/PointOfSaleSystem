using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.Company;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public void CreateCompany(Company company)
        {
            _companyRepository.Create(company);
        }

        public Company GetCompany(Guid id)
        {
            return _companyRepository.Get(id);
        }

        public List<Company> GetAllCompanies()
        {
            return _companyRepository.GetAll();
        }

        public void UpdateCompany(UpdateCompanyRequest request)
        {
            _companyRepository.Update(request);
        }
        
        public void DeleteCompany(Guid id)
        {
            _companyRepository.Delete(id);
        }

    }
}
