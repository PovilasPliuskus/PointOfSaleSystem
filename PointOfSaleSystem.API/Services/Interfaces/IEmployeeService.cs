using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Employees;
using PointOfSaleSystem.API.RequestBodies.UserInfo;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface IEmployeeService
    {
        public void CreateEmployee(AddEmployeeRequest request, UserInfo userInfo);
        public Employee GetEmployee(Guid id, UserInfo userInfo);
        public List<Employee> GetAllEmployees(UserInfo userInfo);
        public void UpdateEmployee(UpdateEmployeeRequest request, UserInfo userInfo);
        public void DeleteEmployee(Guid id, UserInfo userInfo);
    }
}