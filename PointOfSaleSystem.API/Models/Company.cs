namespace PointOfSaleSystem.API.Models
{
    public class Company : BaseModel
    {
        public required string Code { get; set; }
        public ICollection<Establishment>? Establishments { get; set; }
        public ICollection<CompanyProduct>? CompanyProducts { get; set; }
        public ICollection<CompanyService>? CompanyServices { get; set; }
    }
}
