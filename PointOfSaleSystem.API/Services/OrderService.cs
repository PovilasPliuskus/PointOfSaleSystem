using AutoMapper;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.Order;
using PointOfSaleSystem.API.ResponseBodies.FullOrder;
using PointOfSaleSystem.API.ResponseBodies.Order;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IFullOrderRepository _fullOrderRepository;
        private readonly IMapper _mapper;

        public OrderService(
            IOrderRepository orderRepository,
            IFullOrderRepository fullOrderRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _fullOrderRepository = fullOrderRepository;
            _mapper = mapper;
        }

        public void CreateOrder(AddOrderRequest order)
        {
            _orderRepository.Create(order);
        }

        public GetOrderResponse GetOrder(Guid id)
        {
            Order order =  _orderRepository.Get(id);

            Guid relatedFullOrderId = GetFullOrder(order);

            GetOrderResponse response = _mapper.Map<GetOrderResponse>(order);

            response.FullOrderId = relatedFullOrderId;

            return response;
        }

        public List<GetOrderResponse> GetAllOrders()
        {
            List<Order> orders = _orderRepository.GetAll();

            List<GetOrderResponse> fullResponse = [];

            foreach (var order in orders)
            {
                Guid relatedFullOrderId = GetFullOrder(order);

                GetOrderResponse response = _mapper.Map<GetOrderResponse>(order);

                response.FullOrderId = relatedFullOrderId;

                fullResponse.Add(response);
            }

            return fullResponse;
        }

        public void UpdateOrder(UpdateOrderRequest request)
        {
            _orderRepository.Update(request);
        }

        public void DeleteOrder(Guid id)
        {
            _orderRepository.Delete(id);
        }

        private Guid GetFullOrder(Order order)
        {
            List<FullOrder> fullOrders = _fullOrderRepository.GetAll();

            foreach (FullOrder fullOrder in fullOrders)
            {
                if (fullOrder.Orders is not null && fullOrder.Orders.Any(o => o.Id == order.Id))
                {
                    return fullOrder.Id;
                }
            }

            throw new Exception("Order was not found in any FullOrder, this should've not had happened");
        }
    }
}
