using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.CompanyService;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class CompanyServiceController : ControllerBase
    {
        private readonly ICompanyServiceService _companyServiceService;
        private readonly IUserInfoService _userInfoService;

        public CompanyServiceController(ICompanyServiceService companyServiceService,
            IUserInfoService userInfoService)
        {
            _companyServiceService = companyServiceService;
            _userInfoService = userInfoService;
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

            _companyServiceService.CreateCompanyService(request, userInfo);
            return Ok();
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

            List<CompanyService> companyServices = _companyServiceService.GetCompanyServices(userInfo);
            return Ok(companyServices);
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

            CompanyService companyService = _companyServiceService.GetCompanyService(companyServiceId, userInfo);
            return Ok(companyService);
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

            _companyServiceService.UpdateCompanyService(request, userInfo);
            return Ok();
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

            _companyServiceService.DeleteCompanyService(companyServiceId, userInfo);
            return Ok();
        }
    }
}
