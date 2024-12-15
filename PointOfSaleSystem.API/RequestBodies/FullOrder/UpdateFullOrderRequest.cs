namespace PointOfSaleSystem.API.RequestBodies.FullOrder
{
    public class UpdateFullOrderRequest
    {
        public required Guid Id { get; set; }
        public required decimal Tip { get; set; }
        public required int Status { get; set; }
        public required string Name { get; set; }
        public required DateTime UpdateTime { get; set; }
    }
}
