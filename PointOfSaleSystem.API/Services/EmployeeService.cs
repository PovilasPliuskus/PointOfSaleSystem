using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.Company;
using PointOfSaleSystem.API.RequestBodies.Employee;
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

        public void CreateEmployee(Employee employee)
        {
            _employeeRepository.Create(employee);
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
