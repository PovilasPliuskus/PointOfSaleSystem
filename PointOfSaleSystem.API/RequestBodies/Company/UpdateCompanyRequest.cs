namespace PointOfSaleSystem.API.RequestBodies.Company
{
    public class UpdateCompanyRequest
    {
        public required Guid Id { get; set; }
        public required string Code { get; set; }
        public required string Name { get; set; }
    }
}
