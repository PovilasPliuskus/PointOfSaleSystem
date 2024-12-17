using PointOfSaleSystem.API.RequestBodies.EstablishmentService;
using PointOfSaleSystem.API.RequestBodies.UserInfo;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface IEstablishmentServiceService
    {
        public void CreateEstablishmentService(AddEstablishmentServiceRequest request, UserInfo userInfo);
        public Models.EstablishmentService GetEstablishmentService(Guid id, UserInfo userInfo);
        public List<Models.EstablishmentService> GetAllEstablishmnentServices(UserInfo userInfo);
        public void UpdateEstablishmentService(UpdateEstablishmentServiceRequest request, UserInfo userInfo);
        public void DeleteEstablishmentService(Guid id, UserInfo userInfo);
    }
}
