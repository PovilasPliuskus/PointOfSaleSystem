namespace PointOfSaleSystem.API.RequestBodies.Establishment
{
    public class UpdateEstablishmentRequest
    {
        public required Guid Id { get; set; }
        public required string Code { get; set; }
        public required string Name { get; set; }
    }
}