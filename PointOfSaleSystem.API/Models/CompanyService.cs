using PointOfSaleSystem.API.Models.Enums;

namespace PointOfSaleSystem.API.Models
{
    public class CompanyService : BaseModel
    {
        public required Company Company { get; set; }
    }
}
