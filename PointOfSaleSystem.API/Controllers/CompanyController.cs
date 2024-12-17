using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Company;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IUserInfoService _userInfoService;

        public CompanyController(ICompanyService companyService,
            IUserInfoService userInfoService)
        {
            _companyService = companyService;
            _userInfoService = userInfoService;
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

            _companyService.CreateCompany(company, userInfo);
            return Ok();
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

            List<Company> companies = _companyService.GetAllCompanies(userInfo);
            return Ok(companies);
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

            Company company = _companyService.GetCompany(companyId, userInfo);
            return Ok(company);
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

            _companyService.UpdateCompany(request, userInfo);
            return Ok();
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

            _companyService.DeleteCompany(companyId, userInfo);
            return Ok();
        }
    }
}
