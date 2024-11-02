namespace PointOfSaleSystem.API.Models
{
    public class Order : BaseModel
    {
        public Guid? EstablishmentProductId { get; set; }
        public Guid? EstablishmentServiceId { get; set; }
        public required int Count { get; set; }
    }
}
