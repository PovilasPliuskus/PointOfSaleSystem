using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.GiftCard;
using PointOfSaleSystem.API.RequestBodies.Order;

namespace PointOfSaleSystem.API.Repositories.Interfaces
{
    public interface IGiftCardRepository
    {
        public void Create(GiftCard giftcard);
        public GiftCard Get(Guid id);
        public List<GiftCard> GetAll();
        public void Update(UpdateGiftCardRequest request);
        public void Delete(Guid id);
    }
}
