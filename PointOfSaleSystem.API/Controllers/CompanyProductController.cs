using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.CompanyProduct;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.Services.Interfaces;
using Serilog;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class CompanyProductController : ControllerBase
    {
        private readonly ICompanyProductService _companyProductService;
        private readonly IUserInfoService _userInfoService;
        private readonly ILogger<CompanyProductController> _logger;

        public CompanyProductController(ICompanyProductService companyProductService,
            IUserInfoService userInfoService,
            ILogger<CompanyProductController> logger)
        {
            _companyProductService = companyProductService;
            _userInfoService = userInfoService;
            _logger = logger;
        }

        [HttpPost("companyProduct")]
        public async Task<IActionResult> CreateCompanyProduct(AddCompanyProductRequest request)
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
                _companyProductService.CreateCompanyProduct(request, userInfo);
                _logger.LogInformation("Successfully created company product by user {UserId}", userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create company product by user {UserId}", userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("companyProduct")]
        public async Task<IActionResult> GetCompanyProducts()
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
                List<CompanyProduct> companyProducts = _companyProductService.GetCompanyProducts(userInfo);
                _logger.LogInformation("Successfully retrieved company products by user {UserId}", userInfo.Id);
                return Ok(companyProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve company products by user {UserId}", userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("companyProduct/{companyProductId}")]
        public async Task<IActionResult> GetCompanyProduct(Guid companyProductId)
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
                CompanyProduct companyProduct = _companyProductService.GetCompanyProduct(companyProductId, userInfo);
                _logger.LogInformation("Successfully retrieved company product {CompanyProductId} by user {UserId}", companyProductId, userInfo.Id);
                return Ok(companyProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve company product {CompanyProductId} by user {UserId}", companyProductId, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("companyProduct/{companyProductId}")]
        public async Task<IActionResult> UpdateCompanyProduct(UpdateCompanyProductRequest request)
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
                _companyProductService.UpdateCompanyProduct(request, userInfo);
                _logger.LogInformation("Successfully updated company product {CompanyProductId} by user {UserId}", request.Id, userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update company product {CompanyProductId} by user {UserId}", request.Id, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("companyProduct/{companyProductId}")]
        public async Task<IActionResult> DeleteCompanyProduct(Guid companyProductId)
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
                _companyProductService.DeleteCompanyProduct(companyProductId, userInfo);
                _logger.LogInformation("Successfully deleted company product {CompanyProductId} by user {UserId}", companyProductId, userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete company product {CompanyProductId} by user {UserId}", companyProductId, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
