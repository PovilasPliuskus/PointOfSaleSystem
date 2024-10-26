namespace PointOfSaleSystem.API.Models
{
    public class CompanyProduct : BaseModel
    {
        public required bool AlcoholicBeverage { get; set; }
        public required Company Company { get; set; }
    }
}
