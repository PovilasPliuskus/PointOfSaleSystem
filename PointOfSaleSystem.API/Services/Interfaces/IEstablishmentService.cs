using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Establishment;

public interface IEstablishmentService
{
        public void CreateEstablishment(AddEstablishmentRequest establishment);
        public Establishment GetEstablishment(Guid id);
        public List<Establishment> GetAllEstablishments();
        public void UpdateEstablishment(UpdateEstablishmentRequest request);
        public void DeleteEstablishment(Guid id);
}