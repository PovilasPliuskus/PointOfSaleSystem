using PointOfSaleSystem.API.Models;

namespace PointOfSaleSystem.API.ResponseBodies.Order
{
    public class GetOrderResponse : BaseModel
    {
        public Guid? EstablishmentProductId { get; set; }
        public Guid? EstablishmentServiceId { get; set; }
        public required int Count { get; set; }
        public required Guid FullOrderId { get; set; }
    }
}
