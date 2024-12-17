using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.CompanyProduct;
using PointOfSaleSystem.API.RequestBodies.UserInfo;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface ICompanyProductService
    {
        public void CreateCompanyProduct(AddCompanyProductRequest request, UserInfo userInfo);
        public CompanyProduct GetCompanyProduct(Guid id, UserInfo userInfo);
        public List<CompanyProduct> GetCompanyProducts(UserInfo userInfo);
        public void UpdateCompanyProduct(UpdateCompanyProductRequest request, UserInfo userInfo);
        public void DeleteCompanyProduct(Guid id, UserInfo userInfo);
    }
}
