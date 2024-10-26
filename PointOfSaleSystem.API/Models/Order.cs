namespace PointOfSaleSystem.API.Models
{
    public class Order
    {
        public required int Id { get; set; }
        public ICollection<EstablishmentProduct>? EstablishmentProducts { get; set; }
        public ICollection<EstablishmentService>? EstablishmentServices { get; set; }
    }
}
