using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Company;
using PointOfSaleSystem.API.RequestBodies.UserInfo;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface ICompanyService
    {
        public void CreateCompany(Company company, UserInfo userInfo);
        public Company GetCompany(Guid id, UserInfo userInfo);
        public List<Company> GetAllCompanies(UserInfo userInfo);
        public void UpdateCompany(UpdateCompanyRequest request, UserInfo userInfo);
        public void DeleteCompany(Guid id, UserInfo userInfo);
    }
}
