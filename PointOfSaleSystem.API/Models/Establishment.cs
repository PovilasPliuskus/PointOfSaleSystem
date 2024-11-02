namespace PointOfSaleSystem.API.Models
{
    public class Establishment : BaseModel
    {
        public required int Code { get; set; }
        public required Company Company { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<EstablishmentProduct>? EstablishmentProducts { get; set; }
        public ICollection<EstablishmentService>? EstablishmentServices { get; set; }
    }
}
