using Microsoft.AspNetCore.Mvc;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CompanyController : ControllerBase
    {
        public CompanyController()
        {

        }

        [HttpPost("company")]
        public async Task<IActionResult> CreateCompany()
        {
            return Ok();
        }

        [HttpGet("company")]
        public async Task<IActionResult> GetCompanies()
        {
            return Ok();
        }

        [HttpGet("company/{companyId}")]
        public async Task<IActionResult> GetCompany()
        {
            return Ok();
        }

        [HttpPut("company/{companyId}")]
        public async Task<IActionResult> UpdateCompany()
        {
            return Ok();
        }

        [HttpDelete("company/{companyId}")]
        public async Task<IActionResult> DeleteCompany()
        {
            return Ok();
        }
    }
}
