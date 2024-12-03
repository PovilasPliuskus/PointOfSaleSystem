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

        [HttpPost("business")]
        public async Task<IActionResult> CreateBusiness()
        {
            return Ok();
        }

        [HttpGet("business")]
        public async Task<IActionResult> GetBusinesses()
        {
            return Ok();
        }

        [HttpGet("business/{businessId}")]
        public async Task<IActionResult> GetBusiness()
        {
            return Ok();
        }

        [HttpPut("business/{businessId}")]
        public async Task<IActionResult> UpdateBusiness()
        {
            return Ok();
        }

        [HttpDelete("business/{businessId}")]
        public async Task<IActionResult> DeleteBusiness()
        {
            return Ok();
        }
    }
}
