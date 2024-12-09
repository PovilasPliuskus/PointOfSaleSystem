using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Company;

namespace PointOfSaleSystem.API.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        public void Create(Company company);
        public Company Get(Guid id);
        public List<Company> GetAll();
        public void Update(UpdateCompanyRequest request);
        public void Delete(Guid id);
    }
}
