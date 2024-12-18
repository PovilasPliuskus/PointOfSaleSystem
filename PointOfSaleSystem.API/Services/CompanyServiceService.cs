using Azure.Core;
using PointOfSaleSystem.API.Models.Enums;
using PointOfSaleSystem.API.Repositories;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.CompanyService;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Services
{
    public class CompanyServiceService : ICompanyServiceService
    {
        private readonly ICompanyServiceRepository _companyServiceRepository;

        public CompanyServiceService(ICompanyServiceRepository companyServiceRepository)
        {
            _companyServiceRepository = companyServiceRepository;
        }

        public void CreateCompanyService(AddCompanyServiceRequest request, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                _companyServiceRepository.Create(request);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                _companyServiceRepository.Create(request);
            }
        }

        public Models.CompanyService GetCompanyService(Guid id, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                return _companyServiceRepository.Get(id);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                return _companyServiceRepository.Get(id);
            }

            return null;
        }

        public List<Models.CompanyService> GetCompanyServices(UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                return _companyServiceRepository.GetAll();
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                return _companyServiceRepository.GetAllByEmployeeId(Guid.Parse(userInfo.Id));
            }

            return [];
        }

        public void UpdateCompanyService(UpdateCompanyServiceRequest request, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                _companyServiceRepository.Update(request);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                _companyServiceRepository.Update(request);
            }
        }

        public void DeleteCompanyService(Guid id, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                _companyServiceRepository.Delete(id);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                _companyServiceRepository.Delete(id);
            }
        }
    }
}
