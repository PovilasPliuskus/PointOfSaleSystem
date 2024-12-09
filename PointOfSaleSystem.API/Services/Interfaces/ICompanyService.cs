using PointOfSaleSystem.API.Models;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface ICompanyService
    {
        public Company GetCompany(Guid id);
        public List<Company> GetAllCompanies();
    }
}
