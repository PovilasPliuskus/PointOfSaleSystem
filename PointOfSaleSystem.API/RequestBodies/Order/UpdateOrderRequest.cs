namespace PointOfSaleSystem.API.RequestBodies.Order
{
    public class UpdateOrderRequest
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required int Count { get; set; }
    }
}
