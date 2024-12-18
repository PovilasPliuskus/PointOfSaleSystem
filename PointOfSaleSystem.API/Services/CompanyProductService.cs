using Azure.Core;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Enums;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.CompanyProduct;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
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

        public void CreateCompanyProduct(AddCompanyProductRequest request, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                _companyProductRepository.Create(request);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                _companyProductRepository.Create(request);
            }
        }

        public CompanyProduct GetCompanyProduct(Guid id, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                return _companyProductRepository.Get(id);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                return _companyProductRepository.Get(id);
            }

            return null;
        }

        public List<CompanyProduct> GetCompanyProducts(UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                return _companyProductRepository.GetAll();
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                return _companyProductRepository.GetAllByEmployeeId(Guid.Parse(userInfo.Id));
            }

            return [];
        }

        public void UpdateCompanyProduct(UpdateCompanyProductRequest request, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                _companyProductRepository.Update(request);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                _companyProductRepository.Update(request);
            }
        }

        public void DeleteCompanyProduct(Guid id, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                _companyProductRepository.Delete(id);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                _companyProductRepository.Delete(id);
            }
        }
    }
}
