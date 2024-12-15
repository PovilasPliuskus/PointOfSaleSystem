using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.FullOrder;
using PointOfSaleSystem.API.ResponseBodies.FullOrder;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class FullOrderController : ControllerBase
    {
        private readonly IFullOrderService _fullOrderService;

        public FullOrderController(IFullOrderService fullOrderService)
        {
            _fullOrderService = fullOrderService;
        }

        [HttpPost("fullOrder")]
        public async Task<IActionResult> CreateFullOrder(FullOrder fullOrder)
        {
            _fullOrderService.CreateFullOrder(fullOrder);
            return Ok();
        }

        [HttpGet("fullOrder")]
        public async Task<IActionResult> GetFullOrders()
        {
            List<GetFullOrderResponse> fullOrders = _fullOrderService.GetAllFullOrders();
            return Ok(fullOrders);
        }

        [HttpGet("fullOrder/{fullOrderId}")]
        public async Task<IActionResult> GetFullOrder(Guid fullOrderId)
        {
            GetFullOrderResponse fullOrder = _fullOrderService.GetFullOrder(fullOrderId);
            return Ok(fullOrder);
        }

        [HttpPut("fullOrder/{fullOrderId}")]
        public async Task<IActionResult> UpdateFullOrder(UpdateFullOrderRequest request)
        {
            _fullOrderService.UpdateFullOrder(request);
            return Ok();
        }

        [HttpDelete("fullOrder/{fullOrderId}")]
        public async Task<IActionResult> DeleteFullOrder(Guid fullOrderId)
        {
            _fullOrderService.DeleteFullOrder(fullOrderId);
            return Ok();
        }
    }
}
