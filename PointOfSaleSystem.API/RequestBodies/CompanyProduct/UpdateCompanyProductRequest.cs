namespace PointOfSaleSystem.API.RequestBodies.CompanyProduct
{
    public class UpdateCompanyProductRequest
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required bool AlcoholicBeverage { get; set; }
        public required DateTime UpdateTime { get; set; }
    }
}
