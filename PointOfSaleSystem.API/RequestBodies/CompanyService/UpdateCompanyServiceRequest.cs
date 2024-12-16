namespace PointOfSaleSystem.API.RequestBodies.CompanyService
{
    public class UpdateCompanyServiceRequest
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required DateTime UpdateTime { get; set; }
    }
}
