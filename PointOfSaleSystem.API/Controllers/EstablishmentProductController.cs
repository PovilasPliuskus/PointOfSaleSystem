using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.EstablishmentProduct;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class EstablishmentProductController : ControllerBase
    {
        private readonly IEstablishmentProductService _establishmentProductService;

        public EstablishmentProductController(IEstablishmentProductService establishmentProductService)
        {
            _establishmentProductService = establishmentProductService;
        }

        [HttpPost("establishmentProduct")]
        public async Task<IActionResult> CreateEstablishmentProduct(AddEstablishmentProductRequest request)
        {
            _establishmentProductService.CreateEstablishmentProduct(request);
            return Ok();
        }

        [HttpGet("establishmentProduct")]
        public async Task<IActionResult> GetEstablishmentProducts()
        {
            List<EstablishmentProduct> establishmentProducts = _establishmentProductService.GetAllEstablishmentProducts();
            return Ok(establishmentProducts);
        }

        [HttpGet("establishmentProduct/{establishmentProductId}")]
        public async Task<IActionResult> GetEstablishmentProduct(Guid establishmentProductId)
        {
            EstablishmentProduct establishmentProduct = _establishmentProductService.GetEstablishmentProduct(establishmentProductId);
            return Ok(establishmentProduct);
        }

        [HttpPut("establishmentProduct/{establishmentProductId}")]
        public async Task<IActionResult> UpdateEstablishmentProduct(UpdateEstablishmentProductRequest request)
        {
            _establishmentProductService.UpdateEstablishmentProduct(request);
            return Ok();
        }

        [HttpDelete("establishmentProduct/{establishmentProductId}")]
        public async Task<IActionResult> DeleteEstablishmentProduct(Guid establishmentProductId)
        {
            _establishmentProductService.DeleteEstablishmentProduct(establishmentProductId);
            return Ok();
        }
    }
}
