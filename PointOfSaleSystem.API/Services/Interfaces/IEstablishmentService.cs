using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Establishment;
using PointOfSaleSystem.API.RequestBodies.UserInfo;

public interface IEstablishmentService
{
        public void CreateEstablishment(AddEstablishmentRequest establishment, UserInfo userInfo);
        public Establishment GetEstablishment(Guid id, UserInfo userInfo);
        public List<Establishment> GetAllEstablishments(UserInfo userInfo);
        public void UpdateEstablishment(UpdateEstablishmentRequest request, UserInfo userInfo);
        public void DeleteEstablishment(Guid id, UserInfo userInfo);
}