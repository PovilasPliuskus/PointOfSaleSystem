using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Order;
using PointOfSaleSystem.API.ResponseBodies.Order;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService) 
        {
            _orderService = orderService;
        }

        [HttpPost("order")]
        public async Task<IActionResult> CreateOrder(AddOrderRequest order)
        {
            _orderService.CreateOrder(order);
            return Ok();
        }

        [HttpGet("order")]
        public async Task<IActionResult> GetOrders()
        {
            List<GetOrderResponse> orders = _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetOrder(Guid orderId)
        {
            GetOrderResponse order = _orderService.GetOrder(orderId);
            return Ok(order);
        }

        [HttpPut("order/{orderId}")]
        public async Task<IActionResult> UpdateOrder(UpdateOrderRequest request)
        {
            _orderService.UpdateOrder(request);
            return Ok();
        }

        [HttpDelete("order/{orderId}")]
        public async Task<IActionResult> DeleteOrder(Guid orderId)
        {
            _orderService.DeleteOrder(orderId);
            return Ok();
        }
    }
}
