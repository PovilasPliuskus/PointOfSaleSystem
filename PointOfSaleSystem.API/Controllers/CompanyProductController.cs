using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.CompanyProduct;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class CompanyProductController : ControllerBase
    {
        private readonly ICompanyProductService _companyProductService;
        private readonly IUserInfoService _userInfoService;

        public CompanyProductController(ICompanyProductService companyProductService,
            IUserInfoService userInfoService)
        {
            _companyProductService = companyProductService;
            _userInfoService = userInfoService;
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

            _companyProductService.CreateCompanyProduct(request, userInfo);
            return Ok();
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

            List<CompanyProduct> companyProducts = _companyProductService.GetCompanyProducts(userInfo);
            return Ok(companyProducts);
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

            CompanyProduct companyProduct = _companyProductService.GetCompanyProduct(companyProductId, userInfo);
            return Ok(companyProduct);
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

            _companyProductService.UpdateCompanyProduct(request, userInfo);
            return Ok();
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

            _companyProductService.DeleteCompanyProduct(companyProductId, userInfo);
            return Ok();
        }
    }
}
