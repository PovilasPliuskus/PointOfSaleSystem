using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.CompanyProduct;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Services
{
    public class CompanyProductService : ICompanyProductService
    {
        private readonly ICompanyProductRepository _companyProductRepository;

        public CompanyProductService(ICompanyProductRepository companyProductRepository)
        {
            _companyProductRepository = companyProductRepository;
        }

        public void CreateCompanyProduct(AddCompanyProductRequest request)
        {
            _companyProductRepository.Create(request);
        }

        public CompanyProduct GetCompanyProduct(Guid id)
        {
            return _companyProductRepository.Get(id);
        }

        public List<CompanyProduct> GetCompanyProducts()
        {
            return _companyProductRepository.GetAll();
        }

        public void UpdateCompanyProduct(UpdateCompanyProductRequest request)
        {
            _companyProductRepository.Update(request);
        }

        public void DeleteCompanyProduct(Guid id)
        {
            _companyProductRepository.Delete(id);
        }
    }
}
