using PointOfSaleSystem.API.Models;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface ICompanyService
    {
        public List<Company> GetAllCompanies();
    }
}
