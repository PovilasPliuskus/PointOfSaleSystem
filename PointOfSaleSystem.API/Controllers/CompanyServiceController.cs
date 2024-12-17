using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.CompanyService;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class CompanyServiceController : ControllerBase
    {
        private readonly ICompanyServiceService _companyServiceService;

        public CompanyServiceController(ICompanyServiceService companyServiceService)
        {
            _companyServiceService = companyServiceService;
        }

        [HttpPost("companyService")]
        public async Task<IActionResult> CreateCompanyService(AddCompanyServiceRequest request)
        {
            _companyServiceService.CreateCompanyService(request);
            return Ok();
        }

        [HttpGet("companyService")]
        public async Task<IActionResult> GetCompanyServices()
        {
            List<CompanyService> companyServices = _companyServiceService.GetCompanyServices();
            return Ok(companyServices);
        }

        [HttpGet("companyService/{companyServiceId}")]
        public async Task<IActionResult> GetCompanyService(Guid companyServiceId)
        {
            CompanyService companyService = _companyServiceService.GetCompanyService(companyServiceId);
            return Ok(companyService);
        }

        [HttpPut("companyService/{companyServiceId}")]
        public async Task<IActionResult> UpdateCompanyService(UpdateCompanyServiceRequest request)
        {
            _companyServiceService.UpdateCompanyService(request);
            return Ok();
        }

        [HttpDelete("companyService/{companyServiceId}")]
        public async Task<IActionResult> DeleteCompanyService(Guid companyServiceId)
        {
            _companyServiceService.DeleteCompanyService(companyServiceId);
            return Ok();
        }
    }
}
