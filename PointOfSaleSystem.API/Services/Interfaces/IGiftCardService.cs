using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.FullOrder;
using PointOfSaleSystem.API.RequestBodies.GiftCard;
using PointOfSaleSystem.API.RequestBodies.Tax;
using PointOfSaleSystem.API.ResponseBodies.FullOrder;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface IGiftCardService
    {
        public void CreateGiftCard(GiftCard fullOrder);
        public GiftCard GetGiftCard(Guid id);
        public List<GiftCard> GetAllGiftCards();
        public void UpdateGiftCard(UpdateGiftCardRequest request);
        public void DeleteGiftCard(Guid id);
    }
}
