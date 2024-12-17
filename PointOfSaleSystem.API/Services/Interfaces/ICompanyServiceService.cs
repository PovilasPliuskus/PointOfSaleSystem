using PointOfSaleSystem.API.RequestBodies.CompanyService;
using PointOfSaleSystem.API.RequestBodies.UserInfo;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface ICompanyServiceService
    {
        public void CreateCompanyService(AddCompanyServiceRequest request, UserInfo userInfo);
        public Models.CompanyService GetCompanyService(Guid id, UserInfo userInfo);
        public List<Models.CompanyService> GetCompanyServices(UserInfo userInfo);
        public void UpdateCompanyService(UpdateCompanyServiceRequest request, UserInfo userInfo);
        public void DeleteCompanyService(Guid id, UserInfo userInfo);
    }
}
