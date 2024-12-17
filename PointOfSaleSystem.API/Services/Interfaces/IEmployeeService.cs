using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Employees;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface IEmployeeService
    {
        public void CreateEmployee(AddEmployeeRequest request);
        public Employee GetEmployee(Guid id);
        public List<Employee> GetAllEmployees();
        public void UpdateEmployee(UpdateEmployeeRequest request);
        public void DeleteEmployee(Guid id);
    }
}