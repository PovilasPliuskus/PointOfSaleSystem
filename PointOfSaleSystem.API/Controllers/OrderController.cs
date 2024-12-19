using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Order;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.ResponseBodies.Order;
using PointOfSaleSystem.API.Services.Interfaces;
using Serilog;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUserInfoService _userInfoService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService orderService,
            IUserInfoService userInfoService,
            ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _userInfoService = userInfoService;
            _logger = logger;
        }

        [HttpPost("order")]
        public async Task<IActionResult> CreateOrder(AddOrderRequest order)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            try
            {
                _orderService.CreateOrder(order, userInfo);
                _logger.LogInformation("Successfully created order by user {UserId}", userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create order by user {UserId}", userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("order")]
        public async Task<IActionResult> GetOrders()
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            try
            {
                List<GetOrderResponse> orders = _orderService.GetAllOrders(userInfo);
                _logger.LogInformation("Successfully retrieved orders by user {UserId}", userInfo.Id);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve orders by user {UserId}", userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetOrder(Guid orderId)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            try
            {
                GetOrderResponse order = _orderService.GetOrder(orderId, userInfo);
                _logger.LogInformation("Successfully retrieved order {OrderId} by user {UserId}", orderId, userInfo.Id);
                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve order {OrderId} by user {UserId}", orderId, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("order/{orderId}")]
        public async Task<IActionResult> UpdateOrder(UpdateOrderRequest request)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            try
            {
                _orderService.UpdateOrder(request, userInfo);
                _logger.LogInformation("Successfully updated order {OrderId} by user {UserId}", request.Id, userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update order {OrderId} by user {UserId}", request.Id, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("order/{orderId}")]
        public async Task<IActionResult> DeleteOrder(Guid orderId)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            try
            {
                _orderService.DeleteOrder(orderId, userInfo);
                _logger.LogInformation("Successfully deleted order {OrderId} by user {UserId}", orderId, userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete order {OrderId} by user {UserId}", orderId, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
