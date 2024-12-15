using PointOfSaleSystem.API.Models;

namespace PointOfSaleSystem.API.RequestBodies.Order
{
    public class AddOrderRequest : BaseModel
    {
        public Guid? EstablishmentProductId { get; set; }
        public Guid? EstablishmentServiceId { get; set; }
        public required int Count { get; set; }
        public required Guid fkFullOrderId { get; set; }
    }
}
