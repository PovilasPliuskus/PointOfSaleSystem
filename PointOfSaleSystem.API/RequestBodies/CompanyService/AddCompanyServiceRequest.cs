using PointOfSaleSystem.API.Models;

namespace PointOfSaleSystem.API.RequestBodies.CompanyService
{
    public class AddCompanyServiceRequest : BaseModel
    {
        public required Guid fkCompanyId { get; set; }
    }
}
