using PointOfSaleSystem.API.Models.Enums;

namespace PointOfSaleSystem.API.RequestBodies.Tax
{
    public class UpdateTaxRequest
    {
        public required Guid Id { get; set; }
        public required decimal amount { get; set; }
        public required DateTime UpdateTime { get; set; }
    }
}
