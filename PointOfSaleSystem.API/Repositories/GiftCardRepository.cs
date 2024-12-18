using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PointOfSaleSystem.API.Context;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Models.Enums;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.GiftCard;

namespace PointOfSaleSystem.API.Repositories
{
    public class GiftCardRepository : IGiftCardRepository
    {
        private readonly PointOfSaleSystemContext _context;
        private readonly IMapper _mapper;

        public GiftCardRepository(
            PointOfSaleSystemContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(AddGiftCardRequest request)
        {
            GiftCardEntity giftCardEntity = _mapper.Map<GiftCardEntity>(request);

            _context.GiftCards.Add(giftCardEntity);

            _context.SaveChanges();
        }

        public GiftCard Get(Guid id)
        {
            GiftCardEntity? giftCardEntity = GetGiftCardEntity(id);

            return giftCardEntity is null
                ? throw new Exception($"GiftCard with Id {id} not found.")
                : _mapper.Map<GiftCard>(giftCardEntity);
        }

        public List<GiftCard> GetAll()
        {
            List<GiftCardEntity> giftCardEntities = _context.GiftCards.ToList();

            List<GiftCard> giftCards = _mapper.Map<List<GiftCard>>(giftCardEntities);

            return giftCards;
        }

        public void Update(UpdateGiftCardRequest request)
        {
            GiftCardEntity? giftCardEntity = GetGiftCardEntity(request.Id)
                ?? throw new Exception($"GiftCard with Id {request.Id} not found.");

            giftCardEntity.amount = request.amount;

            _context.Update(giftCardEntity);

            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            GiftCardEntity? giftCardEntity = GetGiftCardEntity(id)
                ?? throw new Exception($"GiftCard with Id {id} not found.");

            _context.GiftCards.Remove(giftCardEntity);

            _context.SaveChanges();
        }

        private GiftCardEntity? GetGiftCardEntity(Guid id)
        {
            return _context.GiftCards.FirstOrDefault(c => c.Id == id);
        }
    }
}