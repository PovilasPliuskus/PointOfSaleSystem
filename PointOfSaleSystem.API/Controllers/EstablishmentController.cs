using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Establishment;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.Services.Interfaces;
using Serilog;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class EstablishmentController : ControllerBase
    {
        private readonly IEstablishmentService _establishmentService;
        private readonly IUserInfoService _userInfoService;
        private readonly ILogger<EstablishmentController> _logger;

        public EstablishmentController(IEstablishmentService establishmentService,
            IUserInfoService userInfoService,
            ILogger<EstablishmentController> logger)
        {
            _establishmentService = establishmentService;
            _userInfoService = userInfoService;
            _logger = logger;
        }

        [HttpPost("establishment")]
        public async Task<IActionResult> CreateEstablishment(AddEstablishmentRequest establishment)
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
                _establishmentService.CreateEstablishment(establishment, userInfo);
                _logger.LogInformation("Successfully created establishment by user {UserId}", userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create establishment by user {UserId}", userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("establishment")]
        public async Task<IActionResult> GetEstablishments()
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
                List<Establishment> establishments = _establishmentService.GetAllEstablishments(userInfo);
                _logger.LogInformation("Successfully retrieved establishments by user {UserId}", userInfo.Id);
                return Ok(establishments);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve establishments by user {UserId}", userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("establishment/{establishmentId}")]
        public async Task<IActionResult> GetEstablishment(Guid establishmentId)
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
                Establishment establishment = _establishmentService.GetEstablishment(establishmentId, userInfo);
                _logger.LogInformation("Successfully retrieved establishment {EstablishmentId} by user {UserId}", establishmentId, userInfo.Id);
                return Ok(establishment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve establishment {EstablishmentId} by user {UserId}", establishmentId, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("establishment/{establishmentId}")]
        public async Task<IActionResult> UpdateEstablishment(UpdateEstablishmentRequest request)
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
                _establishmentService.UpdateEstablishment(request, userInfo);
                _logger.LogInformation("Successfully updated establishment {EstablishmentId} by user {UserId}", request.Id, userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update establishment {EstablishmentId} by user {UserId}", request.Id, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("establishment/{establishmentId}")]
        public async Task<IActionResult> DeleteEstablishment(Guid establishmentId)
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
                _establishmentService.DeleteEstablishment(establishmentId, userInfo);
                _logger.LogInformation("Successfully deleted establishment {EstablishmentId} by user {UserId}", establishmentId, userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete establishment {EstablishmentId} by user {UserId}", establishmentId, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}