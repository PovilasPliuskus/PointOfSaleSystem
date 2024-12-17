using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.Employees;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void CreateEmployee(AddEmployeeRequest request)
        {
            _employeeRepository.Create(request);
        }

        public Employee GetEmployee(Guid id)
        {
            return _employeeRepository.Get(id);
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAll();
        }

        public void UpdateEmployee(UpdateEmployeeRequest request)
        {
            _employeeRepository.Update(request);
        }

        public void DeleteEmployee(Guid id)
        {
            _employeeRepository.Delete(id);
        }

    }
}