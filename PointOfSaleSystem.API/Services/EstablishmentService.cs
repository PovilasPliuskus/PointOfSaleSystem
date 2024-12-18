using Azure.Core;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Enums;
using PointOfSaleSystem.API.Repositories;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.Establishment;
using PointOfSaleSystem.API.RequestBodies.UserInfo;

namespace PointOfSaleSystem.API.Services
{
    public class EstablishmentService : IEstablishmentService
    {
        private readonly IEstablishmentRepository _establishmentRepository;

        public EstablishmentService(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }

        public void CreateEstablishment(AddEstablishmentRequest establishment, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                _establishmentRepository.Create(establishment);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                _establishmentRepository.Create(establishment);
            }

        }

        public Establishment GetEstablishment(Guid id, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                return _establishmentRepository.Get(id);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                return _establishmentRepository.Get(id);
            }
            else if (userInfo.Status == EmployeeStatusEnum.Manager.ToString())
            {
                return _establishmentRepository.Get(id);
            }

            return null;
        }

        public List<Establishment> GetAllEstablishments(UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                return _establishmentRepository.GetAll();
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                return _establishmentRepository.GetAllByEmployeeId(Guid.Parse(userInfo.Id));
            }
            else if (userInfo.Status == EmployeeStatusEnum.Manager.ToString())
            {
                return _establishmentRepository.GetByEmployeeId(Guid.Parse(userInfo.Id));
            }

            return [];
        }

        public void UpdateEstablishment(UpdateEstablishmentRequest request, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                _establishmentRepository.Update(request);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                _establishmentRepository.Update(request);
            }

        }

        public void DeleteEstablishment(Guid id, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                _establishmentRepository.Delete(id);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                _establishmentRepository.Delete(id);
            }

        }
    }
}