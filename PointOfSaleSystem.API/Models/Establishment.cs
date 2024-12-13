using System.Text.Json.Serialization;

namespace PointOfSaleSystem.API.Models
{
    public class Establishment : BaseModel
    {
        public required string Code { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<EstablishmentProduct>? EstablishmentProducts { get; set; }
        public ICollection<EstablishmentService>? EstablishmentServices { get; set; }
    }
}
