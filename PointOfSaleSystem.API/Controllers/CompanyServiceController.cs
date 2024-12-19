using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.CompanyService;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.Services.Interfaces;
using Serilog;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class CompanyServiceController : ControllerBase
    {
        private readonly ICompanyServiceService _companyServiceService;
        private readonly IUserInfoService _userInfoService;
        private readonly ILogger<CompanyServiceController> _logger;

        public CompanyServiceController(ICompanyServiceService companyServiceService,
            IUserInfoService userInfoService,
            ILogger<CompanyServiceController> logger)
        {
            _companyServiceService = companyServiceService;
            _userInfoService = userInfoService;
            _logger = logger;
        }

        [HttpPost("companyService")]
        public async Task<IActionResult> CreateCompanyService(AddCompanyServiceRequest request)
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
                _companyServiceService.CreateCompanyService(request, userInfo);
                _logger.LogInformation("Successfully created company service by user {UserId}", userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create company service by user {UserId}", userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("companyService")]
        public async Task<IActionResult> GetCompanyServices()
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
                List<CompanyService> companyServices = _companyServiceService.GetCompanyServices(userInfo);
                _logger.LogInformation("Successfully retrieved company services by user {UserId}", userInfo.Id);
                return Ok(companyServices);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve company services by user {UserId}", userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("companyService/{companyServiceId}")]
        public async Task<IActionResult> GetCompanyService(Guid companyServiceId)
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
                CompanyService companyService = _companyServiceService.GetCompanyService(companyServiceId, userInfo);
                _logger.LogInformation("Successfully retrieved company service {CompanyServiceId} by user {UserId}", companyServiceId, userInfo.Id);
                return Ok(companyService);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve company service {CompanyServiceId} by user {UserId}", companyServiceId, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("companyService/{companyServiceId}")]
        public async Task<IActionResult> UpdateCompanyService(UpdateCompanyServiceRequest request)
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
                _companyServiceService.UpdateCompanyService(request, userInfo);
                _logger.LogInformation("Successfully updated company service {CompanyServiceId} by user {UserId}", request.Id, userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update company service {CompanyServiceId} by user {UserId}", request.Id, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("companyService/{companyServiceId}")]
        public async Task<IActionResult> DeleteCompanyService(Guid companyServiceId)
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
                _companyServiceService.DeleteCompanyService(companyServiceId, userInfo);
                _logger.LogInformation("Successfully deleted company service {CompanyServiceId} by user {UserId}", companyServiceId, userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete company service {CompanyServiceId} by user {UserId}", companyServiceId, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
