using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.EstablishmentProduct;
using PointOfSaleSystem.API.RequestBodies.UserInfo;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface IEstablishmentProductService
    {
        public void CreateEstablishmentProduct(AddEstablishmentProductRequest request, UserInfo userInfo);
        public EstablishmentProduct GetEstablishmentProduct(Guid id, UserInfo userInfo);
        public List<EstablishmentProduct> GetAllEstablishmentProducts(UserInfo userInfo);
        public void UpdateEstablishmentProduct(UpdateEstablishmentProductRequest request, UserInfo userInfo);
        public void DeleteEstablishmentProduct(Guid id, UserInfo userInfo);
    }
}
