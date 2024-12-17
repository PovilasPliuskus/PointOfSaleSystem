using Azure.Core;
using PointOfSaleSystem.API.Models.Enums;
using PointOfSaleSystem.API.Repositories;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.EstablishmentService;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Services
{
    public class EstablishmentServiceService : IEstablishmentServiceService
    {
        private readonly IEstablishmentServiceRepository _establishmentServiceRepository;

        public EstablishmentServiceService(IEstablishmentServiceRepository establishmentServiceRepository)
        {
            _establishmentServiceRepository = establishmentServiceRepository;
        }

        public void CreateEstablishmentService(AddEstablishmentServiceRequest request, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                _establishmentServiceRepository.Create(request);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                _establishmentServiceRepository.Create(request);
            }
            else if (userInfo.Status == EmployeeStatusEnum.Manager.ToString())
            {
                _establishmentServiceRepository.Create(request);
            }

        }

        public Models.EstablishmentService GetEstablishmentService(Guid id, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                return _establishmentServiceRepository.Get(id);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                return _establishmentServiceRepository.Get(id);
            }
            else if (userInfo.Status == EmployeeStatusEnum.Manager.ToString())
            {
                return _establishmentServiceRepository.Get(id);
            }

            return null;

        }

        public List<Models.EstablishmentService> GetAllEstablishmnentServices(UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                return _establishmentServiceRepository.GetAll();
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                return _establishmentServiceRepository.GetAll();
            }
            else if (userInfo.Status == EmployeeStatusEnum.Manager.ToString())
            {
                return _establishmentServiceRepository.GetAll();
            }

            return [];
        }

        public void UpdateEstablishmentService(UpdateEstablishmentServiceRequest request, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                _establishmentServiceRepository.Update(request);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                _establishmentServiceRepository.Update(request);
            }
            else if (userInfo.Status == EmployeeStatusEnum.Manager.ToString())
            {
                _establishmentServiceRepository.Update(request);
            }

        }

        public void DeleteEstablishmentService(Guid id, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                _establishmentServiceRepository.Delete(id);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                _establishmentServiceRepository.Delete(id);
            }
            else if (userInfo.Status == EmployeeStatusEnum.Manager.ToString())
            {
                _establishmentServiceRepository.Delete(id);
            }

        }
    }
}
