using PointOfSaleSystem.API.Models;

namespace PointOfSaleSystem.API.RequestBodies.GiftCard
{
    public class AddGiftCardRequest : BaseModel
    {
        public required decimal Amount { get; set; }
        public required Guid fkGiftFullOrderId { get; set; }
    }
}
