using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Company;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface ICompanyService
    {
        public void CreateCompany(Company company);
        public Company GetCompany(Guid id);
        public List<Company> GetAllCompanies();
        public void UpdateCompany(UpdateCompanyRequest request);
        public void DeleteCompany(Guid id);
    }
}
