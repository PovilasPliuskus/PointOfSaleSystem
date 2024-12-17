using PointOfSaleSystem.API.Models.Enums;

namespace PointOfSaleSystem.API.RequestBodies.GiftCard
{
    public class UpdateGiftCardRequest
    {
        public required Guid Id { get; set; }
        public required CurrencyEnum Currency { get; set; }
        public required decimal amount { get; set; }
        public required DateTime UpdateTime { get; set; }
    }
}
