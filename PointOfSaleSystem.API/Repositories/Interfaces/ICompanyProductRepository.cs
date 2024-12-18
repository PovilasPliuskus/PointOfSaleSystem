using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.CompanyProduct;

namespace PointOfSaleSystem.API.Repositories.Interfaces
{
    public interface ICompanyProductRepository
    {
        public void Create(AddCompanyProductRequest request);
        public CompanyProduct Get(Guid id);
        public List<CompanyProduct> GetAll();
        public void Update(UpdateCompanyProductRequest request);
        public void Delete(Guid id);
        public List<CompanyProduct> GetAllByEmployeeId(Guid employeeId);
    }
}
