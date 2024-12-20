using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.FullOrder;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.ResponseBodies.FullOrder;
using PointOfSaleSystem.API.Services.Interfaces;
using Serilog;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class FullOrderController : ControllerBase
    {
        private readonly IFullOrderService _fullOrderService;
        private readonly IUserInfoService _userInfoService;
        private readonly ILogger<FullOrderController> _logger;

        public FullOrderController(IFullOrderService fullOrderService,
            IUserInfoService userInfoService,
            ILogger<FullOrderController> logger)
        {
            _fullOrderService = fullOrderService;
            _userInfoService = userInfoService;
            _logger = logger;
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

            try
            {
                _fullOrderService.CreateFullOrder(fullOrder, userInfo);
                _logger.LogInformation("Successfully created full order by user {UserId}", userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create full order by user {UserId}", userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
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

            try
            {
                List<GetFullOrderResponse> fullOrders = _fullOrderService.GetAllFullOrders(userInfo);
                _logger.LogInformation("Successfully retrieved full orders by user {UserId}", userInfo.Id);
                return Ok(fullOrders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve full orders by user {UserId}", userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
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

            try
            {
                GetFullOrderResponse fullOrder = _fullOrderService.GetFullOrder(fullOrderId, userInfo);
                _logger.LogInformation("Successfully retrieved full order {FullOrderId} by user {UserId}", fullOrderId, userInfo.Id);
                return Ok(fullOrder);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve full order {FullOrderId} by user {UserId}", fullOrderId, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
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

            try
            {
                _fullOrderService.UpdateFullOrder(request, userInfo);
                _logger.LogInformation("Successfully updated full order {FullOrderId} by user {UserId}", request.Id, userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update full order {FullOrderId} by user {UserId}", request.Id, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
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

            try
            {
                _fullOrderService.DeleteFullOrder(fullOrderId, userInfo);
                _logger.LogInformation("Successfully deleted full order {FullOrderId} by user {UserId}", fullOrderId, userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete full order {FullOrderId} by user {UserId}", fullOrderId, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("fullOrder/refund/{fullOrderId}")]
        public async Task<IActionResult> RefundFullOrder(Guid fullOrderId)
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
                _fullOrderService.RefundFullOrder(fullOrderId, userInfo);
                _logger.LogInformation("Successfully refunded full order {FullOrderId} by user {UserId}", fullOrderId, userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to refund full order {FullOrderId} by user {UserId}", fullOrderId, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
