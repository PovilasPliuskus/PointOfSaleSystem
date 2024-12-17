using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Services.Interfaces;
using PointOfSaleSystem.API.RequestBodies.Tax;
using Microsoft.AspNetCore.Authorization;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class TaxController : ControllerBase
    {
        private readonly ITaxService _taxService;

        public TaxController(ITaxService taxService)
        {
            _taxService = taxService;
        }

        [HttpPost("tax")]
        public async Task<IActionResult> CreateTax(Tax request)
        {
            _taxService.CreateTax(request);
            return Ok();
        }

        [HttpGet("tax")]
        public async Task<IActionResult> GetTaxes()
        {
            List<Tax> taxs = _taxService.GetAllTaxes();
            return Ok(taxs);
        }

        [HttpGet("tax/{taxID}")]
        public async Task<IActionResult> GetTax(Guid taxID)
        {
            Tax tax = _taxService.GetTax(taxID);
            return Ok(tax);
        }

        [HttpPut("tax/{taxID}")]
        public async Task<IActionResult> UpdateTax(UpdateTaxRequest request)
        {
            _taxService.UpdateTax(request);
            return Ok();
        }

        [HttpDelete("tax/{taxID}")]
        public async Task<IActionResult> DeleteTax(Guid taxID)
        {
            _taxService.DeleteTax(taxID);
            return Ok();
        }
    }
}