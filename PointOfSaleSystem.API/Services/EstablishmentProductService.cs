using Azure.Core;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Enums;
using PointOfSaleSystem.API.Repositories;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.EstablishmentProduct;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Services
{
    public class EstablishmentProductService : IEstablishmentProductService
    {
        private readonly IEstablishmentProductRepository _establishmentProductRepository;

        public EstablishmentProductService(IEstablishmentProductRepository establishmentProductRepository)
        {
            _establishmentProductRepository = establishmentProductRepository;
        }

        public void CreateEstablishmentProduct(AddEstablishmentProductRequest request, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                _establishmentProductRepository.Create(request);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                _establishmentProductRepository.Create(request);
            }
            else if (userInfo.Status == EmployeeStatusEnum.Manager.ToString())
            {
                _establishmentProductRepository.Create(request);
            }

        }

        public EstablishmentProduct GetEstablishmentProduct(Guid id, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                return _establishmentProductRepository.Get(id);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                return _establishmentProductRepository.Get(id);
            }
            else if (userInfo.Status == EmployeeStatusEnum.Manager.ToString())
            {
                return _establishmentProductRepository.Get(id);
            }

            return null;
        }

        public List<EstablishmentProduct> GetAllEstablishmentProducts(UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                return _establishmentProductRepository.GetAll();
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                return _establishmentProductRepository.GetAllByEmployeeId(Guid.Parse(userInfo.Id));
            }
            else if (userInfo.Status == EmployeeStatusEnum.Manager.ToString())
            {
                return _establishmentProductRepository.GetEstablishmentProductsByEmployeeId(Guid.Parse(userInfo.Id));
            }

            return [];

        }

        public void UpdateEstablishmentProduct(UpdateEstablishmentProductRequest request, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                _establishmentProductRepository.Update(request);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                _establishmentProductRepository.Update(request);
            }
            else if (userInfo.Status == EmployeeStatusEnum.Manager.ToString())
            {
                _establishmentProductRepository.Update(request);
            }

        }

        public void DeleteEstablishmentProduct(Guid id, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                _establishmentProductRepository.Delete(id);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                _establishmentProductRepository.Delete(id);
            }
            else if (userInfo.Status == EmployeeStatusEnum.Manager.ToString())
            {
                _establishmentProductRepository.Delete(id);
            }

        }
    }
}
