using PointOfSaleSystem.API.RequestBodies.CompanyService;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface ICompanyServiceService
    {
        public void CreateCompanyService(AddCompanyServiceRequest request);
        public Models.CompanyService GetCompanyService(Guid id);
        public List<Models.CompanyService> GetCompanyServices();
        public void UpdateCompanyService(UpdateCompanyServiceRequest request);
        public void DeleteCompanyService(Guid id);
    }
}
