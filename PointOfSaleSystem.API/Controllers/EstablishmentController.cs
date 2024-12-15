using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Establishment;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class EstablishmentController : ControllerBase
    {
        private readonly IEstablishmentService _establishmentService;

        public EstablishmentController(IEstablishmentService establishmentService)
        {
            _establishmentService = establishmentService;
        }

        [HttpPost("establishment")]
        public async Task<IActionResult> CreateEstablishment(AddEstablishmentRequest establishment)
        {
            _establishmentService.CreateEstablishment(establishment);
            return Ok();
        }

        [HttpGet("establishment")]
        public async Task<IActionResult> GetEstablishments()
        {
            List<Establishment> establishments = _establishmentService.GetAllEstablishments();
            return Ok(establishments);
        }

        [HttpGet("establishment/{establishmentId}")]
        public async Task<IActionResult> GetEstablishment(Guid establishmentId)
        {
            Establishment establishment = _establishmentService.GetEstablishment(establishmentId);
            return Ok(establishment);
        }

        [HttpPut("establishment/{establishmentId}")]
        public async Task<IActionResult> UpdateEstablishment(UpdateEstablishmentRequest request)
        {
            _establishmentService.UpdateEstablishment(request);
            return Ok();
        }

        [HttpDelete("establishment/{establishmentId}")]
        public async Task<IActionResult> DeleteEstablishment(Guid establishmentId)
        {
            _establishmentService.DeleteEstablishment(establishmentId);
            return Ok();
        }
    }
}