using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.EstablishmentService;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class EstablishmentServiceController : ControllerBase
    {
        private readonly IEstablishmentServiceService _establishmentServiceService;

        public EstablishmentServiceController(IEstablishmentServiceService establishmentServiceService)
        {
            _establishmentServiceService = establishmentServiceService;
        }

        [HttpPost("establishmentService")]
        public async Task<IActionResult> CreateEstablishmentService(AddEstablishmentServiceRequest request)
        {
            _establishmentServiceService.CreateEstablishmentService(request);
            return Ok();
        }

        [HttpGet("establishmentService")]
        public async Task<IActionResult> GetEstablishmentServices()
        {
            List<EstablishmentService> establishmentServices = _establishmentServiceService.GetAllEstablishmnentServices();
            return Ok(establishmentServices);
        }

        [HttpGet("establishmentService/{establishmentServiceId}")]
        public async Task<IActionResult> GetEstablishmentService(Guid establishmentServiceId)
        {
            EstablishmentService establishmentService = _establishmentServiceService.GetEstablishmentService(establishmentServiceId);
            return Ok(establishmentService);
        }

        [HttpPut("establishmentService/{establishmentServiceId}")]
        public async Task<IActionResult> UpdateEstablishmentService(UpdateEstablishmentServiceRequest request)
        {
            _establishmentServiceService.UpdateEstablishmentService(request);
            return Ok();
        }

        [HttpDelete("establishmentService/{establishmentServiceId}")]
        public async Task<IActionResult> DeleteEstablishmentService(Guid establishmentServiceId)
        {
            _establishmentServiceService.DeleteEstablishmentService(establishmentServiceId);
            return Ok();
        }
    }
}
