using PointOfSaleSystem.API.Models.Enums;

namespace PointOfSaleSystem.API.RequestBodies.Order
{
    public class UpdateOrderRequest
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required int Count { get; set; }
        public required DateTime UpdateTime { get; set; }
        public required OrderStatusEnum Status { get; set; }
    }
}
