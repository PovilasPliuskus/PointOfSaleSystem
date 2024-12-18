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
        private readonly IEstablishmentProductRepository _productRepository;
        private readonly IEstablishmentServiceRepository _serviceRepository;

        public OrderRepository(
            PointOfSaleSystemContext context,
            IMapper mapper,
            IEstablishmentProductRepository productRepository,
            IEstablishmentServiceRepository serviceRepository)
        {
            _context = context;
            _mapper = mapper;
            _productRepository = productRepository;
            _serviceRepository = serviceRepository;
        }

        public void Create(AddOrderRequest order)
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
            orderEntity.UpdateTime = request.UpdateTime;

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

        public List<Order> GetAllByEmployeeId(Guid employeeId)
        {
            List<EstablishmentProduct> allProducts = _productRepository.GetAllByEmployeeId(employeeId);
            List<EstablishmentService> allServices = _serviceRepository.GetAllByEmployeeId(employeeId);
            List<Order> selectedOrders = [];

            foreach (var product in allProducts)
            {
                foreach (var order in product.Orders)
                {
                    selectedOrders.Add(order);
                }
            }

            foreach (var service in allServices)
            {
                foreach (var order in service.Orders)
                {
                    selectedOrders.Add(order);
                }
            }

            return selectedOrders;
        }

        public List<Order> GetOrdersByEmployeeId(Guid employeeId)
        {
            List<EstablishmentProduct> allProducts = _productRepository.GetEstablishmentProductsByEmployeeId(employeeId);
            List<EstablishmentService> allServices = _serviceRepository.GetEstablishmentServiceByEmployeeId(employeeId);
            List<Order> selectedOrders = [];

            foreach (var product in allProducts)
            {
                foreach (var order in product.Orders)
                {
                    selectedOrders.Add(order);
                }
            }

            foreach (var service in allServices)
            {
                foreach (var order in service.Orders)
                {
                    selectedOrders.Add(order);
                }
            }

            return selectedOrders;
        }

        private OrderEntity? GetOrderEntity(Guid id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }
    }
}
