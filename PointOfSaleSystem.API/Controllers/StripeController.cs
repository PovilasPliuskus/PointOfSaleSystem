using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Order;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.ResponseBodies.Order;
using PointOfSaleSystem.API.Services.Interfaces;
using Serilog;
using Stripe;
using Stripe.Checkout;

namespace PointOfSaleSystem.API.Controllers
{
    // send full order id only.
    // here retrieve full order.
    // form it how stripe expects it.
    // redirect to checkout.
    // have success and cancel pages.
    // on success change status to closed, on cancel change status to cancelled.
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class StripeController : ControllerBase
    {
        private readonly IFullOrderService _fullOrderService;
        private readonly IUserInfoService _userInfoService;
        private readonly ILogger<StripeController> _logger;

        public StripeController(IFullOrderService fullOrderService,
            IUserInfoService userInfoService,
            ILogger<StripeController> logger)
        {
            _fullOrderService = fullOrderService;
            _userInfoService = userInfoService;
            _logger = logger;
        }

        [HttpPost("create-checkout-session")]
        public IActionResult CreateCheckoutSession([FromBody] CheckoutSessionRequest request)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            StripeConfiguration.ApiKey = "sk_test_51QXkdiLNotqjmzonJnrbI8gwSNzWnLP6rcIOUzGjqZHolA0B3AmB2IGpB1NQKXLLC7XqmkwHSwppvuugC4NZHKin003stIa0XT";
            var fullOrderId = request.FullOrderId;
            var fullOrder = _fullOrderService.GetFullOrder(new Guid(fullOrderId), userInfo);

            /*
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = request.ProductName,
                        },
                        UnitAmount = request.Amount, // Amount in cents
                    },
                    Quantity = 1,
                },
            },
                Mode = "payment",
                SuccessUrl = "https://your-success-url.com",
                CancelUrl = "https://your-cancel-url.com",
            };

            var service = new SessionService();
            var session = service.Create(options);

            
            return Ok(new { sessionId = session.Id });
            */
            return Ok(new {hello = "hello"});
        }
    }

    public class CheckoutSessionRequest
    {
        public string FullOrderId { get; set; }
    }
}
