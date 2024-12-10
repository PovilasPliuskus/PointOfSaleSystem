using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Company;
using PointOfSaleSystem.API.RequestBodies.Employee;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface IEmployeeService
    {
        public void CreateEmployee(Employee employee);
        public Employee GetEmployee(Guid id);
        public List<Employee> GetAllEmployees();
        public void UpdateEmployee(UpdateEmployeeRequest request);
        public void DeleteEmployee(Guid id);
    }
}
