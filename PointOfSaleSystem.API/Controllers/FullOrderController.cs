using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.FullOrder;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.ResponseBodies.FullOrder;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class FullOrderController : ControllerBase
    {
        private readonly IFullOrderService _fullOrderService;
        private readonly IUserInfoService _userInfoService;

        public FullOrderController(IFullOrderService fullOrderService,
            IUserInfoService userInfoService)
        {
            _fullOrderService = fullOrderService;
            _userInfoService = userInfoService;
        }

        [HttpPost("fullOrder")]
        public async Task<IActionResult> CreateFullOrder(FullOrder fullOrder)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            _fullOrderService.CreateFullOrder(fullOrder, userInfo);
            return Ok();
        }

        [HttpGet("fullOrder")]
        public async Task<IActionResult> GetFullOrders()
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            List<GetFullOrderResponse> fullOrders = _fullOrderService.GetAllFullOrders(userInfo);
            return Ok(fullOrders);
        }

        [HttpGet("fullOrder/{fullOrderId}")]
        public async Task<IActionResult> GetFullOrder(Guid fullOrderId)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            GetFullOrderResponse fullOrder = _fullOrderService.GetFullOrder(fullOrderId, userInfo);
            return Ok(fullOrder);
        }

        [HttpPut("fullOrder/{fullOrderId}")]
        public async Task<IActionResult> UpdateFullOrder(UpdateFullOrderRequest request)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            _fullOrderService.UpdateFullOrder(request, userInfo);
            return Ok();
        }

        [HttpDelete("fullOrder/{fullOrderId}")]
        public async Task<IActionResult> DeleteFullOrder(Guid fullOrderId)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            _fullOrderService.DeleteFullOrder(fullOrderId, userInfo);
            return Ok();
        }
    }
}
