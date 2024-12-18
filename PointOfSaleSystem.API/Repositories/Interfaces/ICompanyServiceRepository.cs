using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.CompanyService;

namespace PointOfSaleSystem.API.Repositories.Interfaces
{
    public interface ICompanyServiceRepository
    {
        public void Create(AddCompanyServiceRequest request);
        public Models.CompanyService Get(Guid id);
        public List<Models.CompanyService> GetAll();
        public void Update(UpdateCompanyServiceRequest request);
        public void Delete(Guid id);
        public List<CompanyService> GetAllByEmployeeId(Guid employeeId);
    }
}
