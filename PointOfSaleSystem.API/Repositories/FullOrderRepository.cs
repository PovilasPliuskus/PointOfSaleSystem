using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PointOfSaleSystem.API.Context;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.FullOrder;

namespace PointOfSaleSystem.API.Repositories
{
    public class FullOrderRepository : IFullOrderRepository
    {
        private readonly PointOfSaleSystemContext _context;
        private readonly IMapper _mapper;

        public FullOrderRepository(PointOfSaleSystemContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(FullOrder fullOrder)
        {
            FullOrderEntity fullOrderEntity = _mapper.Map<FullOrderEntity>(fullOrder);

            _context.FullOrders.Add(fullOrderEntity);

            _context.SaveChanges();
        }

        public FullOrder Get(Guid id)
        {
            FullOrderEntity? fullOrderEntity = GetFullOrderEntity(id);

            return fullOrderEntity is null
                ? throw new Exception($"FullOrder with Id {id} not found.")
                : _mapper.Map<FullOrder>(fullOrderEntity);
        }

        public List<FullOrder> GetAll()
        {
            List<FullOrderEntity> fullOrderEntity = _context.FullOrders
                .Include(fo => fo.Orders)
                .Include(fo => fo.Taxes)
                .Include(fo => fo.GiftCards)
                .ToList();

            List<FullOrder> fullOrders = _mapper.Map<List<FullOrder>>(fullOrderEntity);

            return fullOrders;
        }

        public void Update(UpdateFullOrderRequest request)
        {
            FullOrderEntity fullOrderEntity = GetFullOrderEntity(request.Id)
                ?? throw new Exception($"FullOrder with Id {request.Id} not found.");

            fullOrderEntity.Tip = request.Tip;
            fullOrderEntity.Status = (Models.Enums.OrderStatusEnum)request.Status;
            fullOrderEntity.Name = request.Name;
            fullOrderEntity.UpdateTime = request.UpdateTime;

            _context.Update(fullOrderEntity);

            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            FullOrderEntity? fullOrderEntity = GetFullOrderEntity(id)
                ?? throw new Exception($"FullOrder with Id {id} not found.");

            _context.FullOrders.Remove(fullOrderEntity);

            _context.SaveChanges();
        }

        private FullOrderEntity? GetFullOrderEntity(Guid id)
        {
            return _context.FullOrders
                .Include(fo => fo.Orders)
                .Include(fo => fo.Taxes)
                .Include(fo => fo.GiftCards)
                .FirstOrDefault(fo => fo.Id == id);
        }
    }
}
