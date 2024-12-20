using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Company;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.Services.Interfaces;
using Serilog;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IUserInfoService _userInfoService;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ICompanyService companyService,
            IUserInfoService userInfoService,
            ILogger<CompanyController> logger)
        {
            _companyService = companyService;
            _userInfoService = userInfoService;
            _logger = logger;
        }

        [HttpPost("company")]
        public async Task<IActionResult> CreateCompany(Company company)
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
                _companyService.CreateCompany(company, userInfo);
                _logger.LogInformation("Successfully created company by user {UserId}", userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create company by user {UserId}", userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("company")]
        public async Task<IActionResult> GetCompanies()
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
                List<Company> companies = _companyService.GetAllCompanies(userInfo);
                _logger.LogInformation("Successfully retrieved companies by user {UserId}", userInfo.Id);
                return Ok(companies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve companies by user {UserId}", userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("company/{companyId}")]
        public async Task<IActionResult> GetCompany(Guid companyId)
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
                Company company = _companyService.GetCompany(companyId, userInfo);
                _logger.LogInformation("Successfully retrieved company {CompanyId} by user {UserId}", companyId, userInfo.Id);
                return Ok(company);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve company {CompanyId} by user {UserId}", companyId, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("company/{companyId}")]
        public async Task<IActionResult> UpdateCompany(UpdateCompanyRequest request)
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
                _companyService.UpdateCompany(request, userInfo);
                _logger.LogInformation("Successfully updated company {CompanyId} by user {UserId}", request.Id, userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update company {CompanyId} by user {UserId}", request.Id, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("company/{companyId}")]
        public async Task<IActionResult> DeleteCompany(Guid companyId)
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
                _companyService.DeleteCompany(companyId, userInfo);
                _logger.LogInformation("Successfully deleted company {CompanyId} by user {UserId}", companyId, userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete company {CompanyId} by user {UserId}", companyId, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
