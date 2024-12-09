namespace PointOfSaleSystem.API.RequestBodies.Company
{
    public class UpdateCompanyRequest
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
    }
}
