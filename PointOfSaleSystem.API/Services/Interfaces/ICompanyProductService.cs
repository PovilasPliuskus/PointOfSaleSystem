using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.CompanyProduct;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface ICompanyProductService
    {
        public void CreateCompanyProduct(AddCompanyProductRequest request);
        public CompanyProduct GetCompanyProduct(Guid id);
        public List<CompanyProduct> GetCompanyProducts();
        public void UpdateCompanyProduct(UpdateCompanyProductRequest request);
        public void DeleteCompanyProduct(Guid id);
    }
}
