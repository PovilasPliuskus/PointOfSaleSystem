using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Services.Interfaces;
using PointOfSaleSystem.API.RequestBodies.GiftCard;
using Microsoft.AspNetCore.Authorization;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class GiftCardController : ControllerBase
    {
        private readonly IGiftCardService _giftCardService;

        public GiftCardController(IGiftCardService giftCardService)
        {
            _giftCardService = giftCardService;
        }

        [HttpPost("giftCard")]
        public async Task<IActionResult> CreateGiftCard(AddGiftCardRequest request)
        {
            _giftCardService.CreateGiftCard(request);
            return Ok();
        }

        [HttpGet("giftCard")]
        public async Task<IActionResult> GetGiftCardes()
        {
            List<GiftCard> giftCards = _giftCardService.GetAllGiftCards();
            return Ok(giftCards);
        }

        [HttpGet("giftCard/{giftCardID}")]
        public async Task<IActionResult> GetGiftCard(Guid giftCardID)
        {
            GiftCard giftCard = _giftCardService.GetGiftCard(giftCardID);
            return Ok(giftCard);
        }

        [HttpPut("giftCard/{giftCardID}")]
        public async Task<IActionResult> UpdateGiftCard(UpdateGiftCardRequest request)
        {
            _giftCardService.UpdateGiftCard(request);
            return Ok();
        }

        [HttpDelete("giftCard/{giftCardID}")]
        public async Task<IActionResult> DeleteGiftCard(Guid giftCardID)
        {
            _giftCardService.DeleteGiftCard(giftCardID);
            return Ok();
        }
    }
}