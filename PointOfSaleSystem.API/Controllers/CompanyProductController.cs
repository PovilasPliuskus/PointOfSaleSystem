using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.CompanyProduct;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class CompanyProductController : ControllerBase
    {
        private readonly ICompanyProductService _companyProductService;

        public CompanyProductController(ICompanyProductService companyProductService)
        {
            _companyProductService = companyProductService;
        }

        [HttpPost("companyProduct")]
        public async Task<IActionResult> CreateCompanyProduct(AddCompanyProductRequest request)
        {
            _companyProductService.CreateCompanyProduct(request);
            return Ok();
        }

        [HttpGet("companyProduct")]
        public async Task<IActionResult> GetCompanyProducts()
        {
            List<CompanyProduct> companyProducts = _companyProductService.GetCompanyProducts();
            return Ok(companyProducts);
        }

        [HttpGet("companyProduct/{companyProductId}")]
        public async Task<IActionResult> GetCompanyProduct(Guid companyProductId)
        {
            CompanyProduct companyProduct = _companyProductService.GetCompanyProduct(companyProductId);
            return Ok(companyProduct);
        }

        [HttpPut("companyProduct/{companyProductId}")]
        public async Task<IActionResult> UpdateCompanyProduct(UpdateCompanyProductRequest request)
        {
            _companyProductService.UpdateCompanyProduct(request);
            return Ok();
        }

        [HttpDelete("companyProduct/{companyProductId}")]
        public async Task<IActionResult> DeleteCompanyProduct(Guid companyProductId)
        {
            _companyProductService.DeleteCompanyProduct(companyProductId);
            return Ok();
        }
    }
}
