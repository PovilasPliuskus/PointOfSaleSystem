using PointOfSaleSystem.API.Models.Enums;
using PointOfSaleSystem.API.Models;

namespace PointOfSaleSystem.API.ResponseBodies.FullOrder
{
    public class GetFullOrderResponse : BaseModel
    {
        public required ICollection<Order>? Orders { get; set; }
        public required decimal Tip { get; set; }
        public required OrderStatusEnum Status { get; set; }
        public required CurrencyEnum Currency { get; set; }
        public required decimal TotalPrice { get; set; }
    }
}
