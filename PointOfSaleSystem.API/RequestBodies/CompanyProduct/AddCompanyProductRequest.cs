using PointOfSaleSystem.API.Models;

namespace PointOfSaleSystem.API.RequestBodies.CompanyProduct
{
    public class AddCompanyProductRequest : BaseModel
    {
        public required bool AlcoholicBeverage { get; set; }
        public required Guid fkCompanyId { get; set; }
    }
}
