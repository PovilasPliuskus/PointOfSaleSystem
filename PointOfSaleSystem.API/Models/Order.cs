namespace PointOfSaleSystem.API.Models
{
    public class Order : BaseModel
    {
        public ICollection<EstablishmentProduct>? EstablishmentProducts { get; set; }
        public ICollection<EstablishmentService>? EstablishmentServices { get; set; }
        public required FullOrder FullOrder { get; set; }
    }
}
