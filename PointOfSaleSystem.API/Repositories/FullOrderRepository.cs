using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PointOfSaleSystem.API.Context;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Models.Enums;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.FullOrder;
using PointOfSaleSystem.API.RequestBodies.Order;

namespace PointOfSaleSystem.API.Repositories
{
    public class FullOrderRepository : IFullOrderRepository
    {
        private readonly PointOfSaleSystemContext _context;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IEstablishmentRepository _establishmentRepository;
        private readonly ILogger<FullOrderRepository> _logger;

        public FullOrderRepository(PointOfSaleSystemContext context,
            IMapper mapper,
            IOrderRepository orderRepository,
            IEstablishmentRepository establishmentRepository,
            ILogger<FullOrderRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _orderRepository = orderRepository;
            _establishmentRepository = establishmentRepository;
            _logger = logger;
        }

        public void Create(FullOrder fullOrder)
        {
            FullOrderEntity fullOrderEntity = _mapper.Map<FullOrderEntity>(fullOrder);
            fullOrderEntity.fkEstablishmentId = fullOrder.EstablishmentId;

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

        public void RefundFullOrder(Guid id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    FullOrder fullOrder = Get(id);
                    if (fullOrder == null)
                    {
                        throw new Exception($"FullOrder with Id {id} not found.");
                    }

                    foreach (var order in fullOrder.Orders ?? new List<Order>())
                    {
                        order.Status = OrderStatusEnum.Refunded;
                        var updateOrderRequest = new UpdateOrderRequest
                        {
                            Id = order.Id,
                            Name = order.Name,
                            Count = order.Count,
                            Status = order.Status,
                            UpdateTime = DateTime.UtcNow
                        };
                        _orderRepository.Update(updateOrderRequest);
                    }

                    fullOrder.Status = OrderStatusEnum.Refunded;
                    var updateRequest = new UpdateFullOrderRequest
                    {
                        Id = fullOrder.Id,
                        Tip = fullOrder.Tip,
                        Status = (int)fullOrder.Status,
                        Name = fullOrder.Name,
                        UpdateTime = DateTime.UtcNow
                    };
                    Update(updateRequest);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogError(ex, "Failed to refund full order with Id {FullOrderId}", id);
                    throw;
                }
            }
        }

        public List<FullOrder> GetAllByEmployeeId(Guid employeeId)
        {
            List<Establishment> allEstablishments = _establishmentRepository.GetAllByEmployeeId(employeeId);
            List<FullOrder> selectedFullOrders = new List<FullOrder>();

            foreach (var establishment in allEstablishments)
            {
                foreach (var fullOrder in establishment.FullOrders ?? new List<FullOrder>()) // Handle possible null reference
                {
                    selectedFullOrders.Add(fullOrder);
                }
            }

            return selectedFullOrders;
        }

        public List<FullOrder> GetFullOrderByEmployeeId(Guid employeeId)
        {
            List<Establishment> allEstablishments = _establishmentRepository.GetByEmployeeId(employeeId);
            List<FullOrder> selectedFullOrders = new List<FullOrder>();

            foreach (var establishment in allEstablishments)
            {
                foreach (var fullOrder in establishment.FullOrders ?? new List<FullOrder>()) // Handle possible null reference
                {
                    selectedFullOrders.Add(fullOrder);
                }
            }

            return selectedFullOrders;
        }

        private FullOrderEntity? GetFullOrderEntity(Guid id)
        {
            return _context.FullOrders
                .Include(fo => fo.Orders)
                .FirstOrDefault(fo => fo.Id == id);
        }
    }
}
