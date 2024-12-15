using PointOfSaleSystem.API.Models;

namespace PointOfSaleSystem.API.RequestBodies.Establishment
{
    public class AddEstablishmentRequest : BaseModel
    {
        public required string Code { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<EstablishmentProduct>? EstablishmentProducts { get; set; }
        public ICollection<EstablishmentService>? EstablishmentServices { get; set; }
        public required Guid fkCompanyId { get; set; }
    }
}
