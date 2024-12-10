using AutoMapper;
using PointOfSaleSystem.API.Context;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.Order;

namespace PointOfSaleSystem.API.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PointOfSaleSystemContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(
            PointOfSaleSystemContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(Order order)
        {
            OrderEntity orderEntity = _mapper.Map<OrderEntity>(order);

            _context.Orders.Add(orderEntity);

            _context.SaveChanges();
        }

        public Order Get(Guid id)
        {
            OrderEntity? orderEntity = GetOrderEntity(id);

            return orderEntity is null
                ? throw new Exception($"Order with Id {id} not found.")
                : _mapper.Map<Order>(orderEntity);
        }

        public List<Order> GetAll()
        {
            List<OrderEntity> orderEntities = _context.Orders.ToList();

            List<Order> orders = _mapper.Map<List<Order>>(orderEntities);

            return orders;
        }

        public void Update(UpdateOrderRequest request)
        {
            OrderEntity? orderEntity = GetOrderEntity(request.Id)
                ?? throw new Exception($"Order with Id {request.Id} not found.");

            orderEntity.Count = request.Count;
            orderEntity.Name = request.Name;

            _context.Update(orderEntity);

            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            OrderEntity? orderEntity = GetOrderEntity(id)
                ?? throw new Exception($"Order with Id {id} not found.");

            _context.Orders.Remove(orderEntity);

            _context.SaveChanges();
        }

        private OrderEntity? GetOrderEntity(Guid id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }
    }
}
