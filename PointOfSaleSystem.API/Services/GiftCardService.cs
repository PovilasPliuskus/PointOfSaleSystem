using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.FullOrder;
using PointOfSaleSystem.API.RequestBodies.GiftCard;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Services
{
    public class GiftCardService : IGiftCardService
    {
        private readonly IGiftCardRepository _giftCardRepository;

        public GiftCardService(IGiftCardRepository giftCardRepository)
        {
            _giftCardRepository = giftCardRepository;
        }

        public void CreateGiftCard(GiftCard request)
        {
            _giftCardRepository.Create(request);
        }

        public GiftCard GetGiftCard(Guid id)
        {
            return _giftCardRepository.Get(id);
        }

        public List<GiftCard> GetAllGiftCards()
        {
            return _giftCardRepository.GetAll();
        }

        public void UpdateGiftCard(UpdateGiftCardRequest request)
        {
            _giftCardRepository.Update(request);
        }

        public void DeleteGiftCard(Guid id)
        {
            _giftCardRepository.Delete(id);
        }
    }
}