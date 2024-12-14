using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Company;
using PointOfSaleSystem.API.RequestBodies.Employee;

namespace PointOfSaleSystem.API.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        public void Create(Employee employee);
        public Employee Get(Guid id);
        public List<Employee> GetAll();
        public void Update(UpdateEmployeeRequest request);
        public void Delete(Guid id);
    }
}
