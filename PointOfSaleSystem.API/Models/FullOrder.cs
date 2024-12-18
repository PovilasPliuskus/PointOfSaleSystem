using PointOfSaleSystem.API.Models.Enums;

namespace PointOfSaleSystem.API.Models
{
    public class FullOrder : BaseModel
    {
        public required ICollection<Order>? Orders { get; set; }
        public required decimal Tip { get; set; }
        public required OrderStatusEnum Status { get; set; }
        public required Guid EstablishmentId { get; set; }
    }
}
