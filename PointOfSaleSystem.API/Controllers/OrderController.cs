using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Order;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.ResponseBodies.Order;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUserInfoService _userInfoService;
        public OrderController(IOrderService orderService,
            IUserInfoService userInfoService) 
        {
            _orderService = orderService;
            _userInfoService = userInfoService;
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

            _orderService.CreateOrder(order, userInfo);
            return Ok();
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

            List<GetOrderResponse> orders = _orderService.GetAllOrders(userInfo);
            return Ok(orders);
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

            GetOrderResponse order = _orderService.GetOrder(orderId, userInfo);
            return Ok(order);
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

            _orderService.UpdateOrder(request, userInfo);
            return Ok();
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

            _orderService.DeleteOrder(orderId, userInfo);
            return Ok();
        }
    }
}
