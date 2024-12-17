using Azure.Core;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Enums;
using PointOfSaleSystem.API.Repositories;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.Employees;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PointOfSaleSystem.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void CreateEmployee(AddEmployeeRequest request, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                _employeeRepository.Create(request);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                _employeeRepository.Create(request);
            }
            else if (userInfo.Status == EmployeeStatusEnum.Manager.ToString())
            {
                _employeeRepository.Create(request);
            }

        }

        public Employee GetEmployee(Guid id, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                return _employeeRepository.Get(id);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                return _employeeRepository.Get(id);
            }
            else if (userInfo.Status == EmployeeStatusEnum.Manager.ToString())
            {
                return _employeeRepository.Get(id);
            }

            return null;
        }

        public List<Employee> GetAllEmployees(UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                return _employeeRepository.GetAll();
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                return _employeeRepository.GetAll();
            }
            else if (userInfo.Status == EmployeeStatusEnum.Manager.ToString())
            {
                return _employeeRepository.GetAll();
            }

            return [];
        }

        public void UpdateEmployee(UpdateEmployeeRequest request, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                _employeeRepository.Update(request);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                _employeeRepository.Update(request);
            }
            else if (userInfo.Status == EmployeeStatusEnum.Manager.ToString())
            {
                _employeeRepository.Update(request);
            }

        }

        public void DeleteEmployee(Guid id, UserInfo userInfo)
        {
            if (userInfo.Status == EmployeeStatusEnum.Admin.ToString())
            {
                _employeeRepository.Delete(id);
            }
            else if (userInfo.Status == EmployeeStatusEnum.CompanyOwner.ToString())
            {
                _employeeRepository.Delete(id);
            }
            else if (userInfo.Status == EmployeeStatusEnum.Manager.ToString())
            {
                _employeeRepository.Delete(id);
            }

        }

    }
}