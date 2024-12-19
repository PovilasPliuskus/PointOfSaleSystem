using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.EstablishmentService;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.Services.Interfaces;
using Serilog;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class EstablishmentServiceController : ControllerBase
    {
        private readonly IEstablishmentServiceService _establishmentServiceService;
        private readonly IUserInfoService _userInfoService;
        private readonly ILogger<EstablishmentServiceController> _logger;

        public EstablishmentServiceController(IEstablishmentServiceService establishmentServiceService,
            IUserInfoService userInfoService,
            ILogger<EstablishmentServiceController> logger)
        {
            _establishmentServiceService = establishmentServiceService;
            _userInfoService = userInfoService;
            _logger = logger;
        }

        [HttpPost("establishmentService")]
        public async Task<IActionResult> CreateEstablishmentService(AddEstablishmentServiceRequest request)
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
                _establishmentServiceService.CreateEstablishmentService(request, userInfo);
                _logger.LogInformation("Successfully created establishment service by user {UserId}", userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create establishment service by user {UserId}", userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("establishmentService")]
        public async Task<IActionResult> GetEstablishmentServices()
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
                List<EstablishmentService> establishmentServices = _establishmentServiceService.GetAllEstablishmnentServices(userInfo);
                _logger.LogInformation("Successfully retrieved establishment services by user {UserId}", userInfo.Id);
                return Ok(establishmentServices);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve establishment services by user {UserId}", userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("establishmentService/{establishmentServiceId}")]
        public async Task<IActionResult> GetEstablishmentService(Guid establishmentServiceId)
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
                EstablishmentService establishmentService = _establishmentServiceService.GetEstablishmentService(establishmentServiceId, userInfo);
                _logger.LogInformation("Successfully retrieved establishment service {EstablishmentServiceId} by user {UserId}", establishmentServiceId, userInfo.Id);
                return Ok(establishmentService);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve establishment service {EstablishmentServiceId} by user {UserId}", establishmentServiceId, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("establishmentService/{establishmentServiceId}")]
        public async Task<IActionResult> UpdateEstablishmentService(UpdateEstablishmentServiceRequest request)
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
                _establishmentServiceService.UpdateEstablishmentService(request, userInfo);
                _logger.LogInformation("Successfully updated establishment service {EstablishmentServiceId} by user {UserId}", request.Id, userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update establishment service {EstablishmentServiceId} by user {UserId}", request.Id, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("establishmentService/{establishmentServiceId}")]
        public async Task<IActionResult> DeleteEstablishmentService(Guid establishmentServiceId)
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
                _establishmentServiceService.DeleteEstablishmentService(establishmentServiceId, userInfo);
                _logger.LogInformation("Successfully deleted establishment service {EstablishmentServiceId} by user {UserId}", establishmentServiceId, userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete establishment service {EstablishmentServiceId} by user {UserId}", establishmentServiceId, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
