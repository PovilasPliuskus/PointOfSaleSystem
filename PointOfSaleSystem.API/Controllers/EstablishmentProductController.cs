using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.EstablishmentProduct;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.Services.Interfaces;
using Serilog;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class EstablishmentProductController : ControllerBase
    {
        private readonly IEstablishmentProductService _establishmentProductService;
        private readonly IUserInfoService _userInfoService;
        private readonly ILogger<EstablishmentProductController> _logger;

        public EstablishmentProductController(IEstablishmentProductService establishmentProductService,
            IUserInfoService userInfoService,
            ILogger<EstablishmentProductController> logger)
        {
            _establishmentProductService = establishmentProductService;
            _userInfoService = userInfoService;
            _logger = logger;
        }

        [HttpPost("establishmentProduct")]
        public async Task<IActionResult> CreateEstablishmentProduct(AddEstablishmentProductRequest request)
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
                _establishmentProductService.CreateEstablishmentProduct(request, userInfo);
                _logger.LogInformation("Successfully created establishment product by user {UserId}", userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create establishment product by user {UserId}", userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("establishmentProduct")]
        public async Task<IActionResult> GetEstablishmentProducts()
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
                List<EstablishmentProduct> establishmentProducts = _establishmentProductService.GetAllEstablishmentProducts(userInfo);
                _logger.LogInformation("Successfully retrieved establishment products by user {UserId}", userInfo.Id);
                return Ok(establishmentProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve establishment products by user {UserId}", userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("establishmentProduct/{establishmentProductId}")]
        public async Task<IActionResult> GetEstablishmentProduct(Guid establishmentProductId)
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
                EstablishmentProduct establishmentProduct = _establishmentProductService.GetEstablishmentProduct(establishmentProductId, userInfo);
                _logger.LogInformation("Successfully retrieved establishment product {EstablishmentProductId} by user {UserId}", establishmentProductId, userInfo.Id);
                return Ok(establishmentProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve establishment product {EstablishmentProductId} by user {UserId}", establishmentProductId, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("establishmentProduct/{establishmentProductId}")]
        public async Task<IActionResult> UpdateEstablishmentProduct(UpdateEstablishmentProductRequest request)
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
                _establishmentProductService.UpdateEstablishmentProduct(request, userInfo);
                _logger.LogInformation("Successfully updated establishment product {EstablishmentProductId} by user {UserId}", request.Id, userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update establishment product {EstablishmentProductId} by user {UserId}", request.Id, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("establishmentProduct/{establishmentProductId}")]
        public async Task<IActionResult> DeleteEstablishmentProduct(Guid establishmentProductId)
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
                _establishmentProductService.DeleteEstablishmentProduct(establishmentProductId, userInfo);
                _logger.LogInformation("Successfully deleted establishment product {EstablishmentProductId} by user {UserId}", establishmentProductId, userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete establishment product {EstablishmentProductId} by user {UserId}", establishmentProductId, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
