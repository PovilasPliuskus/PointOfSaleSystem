using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Employees;

namespace PointOfSaleSystem.API.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        public void Create(AddEmployeeRequest request);
        public Employee Get(Guid id);
        public List<Employee> GetAll();
        public void Update(UpdateEmployeeRequest request);
        public void Delete(Guid id);
    }
}
