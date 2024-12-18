using PointOfSaleSystem.API.Models;

namespace PointOfSaleSystem.API.RequestBodies.Tax
{
    public class AddTaxRequest : BaseModel
    {
        public required decimal Amount { get; set; }
        public required Guid fkTaxFullOrderId { get; set; }
    }
}
