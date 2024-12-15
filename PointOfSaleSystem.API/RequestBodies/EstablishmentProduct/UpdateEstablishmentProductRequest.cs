namespace PointOfSaleSystem.API.RequestBodies.EstablishmentProduct
{
    public class UpdateEstablishmentProductRequest
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required uint AmountInStock { get; set; }
        public required int Currency { get; set; }
        public required DateTime UpdateTime { get; set; }
    }
}
