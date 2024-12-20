using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Order;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.ResponseBodies.Order;
using PointOfSaleSystem.API.Services;
using PointOfSaleSystem.API.Services.Interfaces;
using Serilog;
using Stripe;
using Stripe.Checkout;
using Stripe.Climate;

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
        private readonly IEstablishmentProductService _establishmentProductService;
        private readonly IEstablishmentServiceService _establishmentServiceService;
        private readonly IUserInfoService _userInfoService;
        private readonly ILogger<StripeController> _logger;

        public StripeController(IFullOrderService fullOrderService,
            IEstablishmentProductService establishmentProductService,
            IEstablishmentServiceService establishmentServiceService,
            IUserInfoService userInfoService,
            ILogger<StripeController> logger)
        {
            _fullOrderService = fullOrderService;
            _establishmentProductService = establishmentProductService;
            _establishmentServiceService = establishmentServiceService;
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
            var fullOrderResponse = _fullOrderService.GetFullOrder(new Guid(fullOrderId), userInfo);








            // Build the list of line items for the checkout session
            var lineItems = new List<SessionLineItemOptions>();

            // Iterate over the orders in the fullOrder to create line items
            foreach (var order in fullOrderResponse.Orders) // Assuming Orders is a collection of items
            {
                // Retrieve product or service details (price from either EstablishmentProduct or EstablishmentService)
                decimal price = 0;
                string productName = "Unknown Product";

                // Check if EstablishmentProductId is available
                if (order.EstablishmentProductId != null)
                {
                    var myProduct = _establishmentProductService.GetEstablishmentProduct((Guid)order.EstablishmentProductId, userInfo);
                    price = myProduct?.Price ?? 0;
                    productName = myProduct?.Name ?? "Unknown Product";
                }
                // Check if EstablishmentServiceId is available
                else if (order.EstablishmentServiceId != null)
                {
                    var myService = _establishmentServiceService.GetEstablishmentService((Guid)order.EstablishmentServiceId, userInfo);
                    price = myService?.Price ?? 0;
                    productName = myService?.Name ?? "Unknown Service";
                }

                if (price > 0)
                {
                    // Convert price to cents (Stripe expects amount in smallest currency unit)
                    long unitAmount = (long)(price * 100); // Assuming price is in dollars, convert to cents

                    // Add the line item for this order
                    lineItems.Add(new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "usd", // Currency type
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = productName,
                            },
                            UnitAmount = unitAmount, // The price in cents
                        },
                        Quantity = order.Count, // Quantity from the order
                    });
                }
            }

            // Optional: Add tip as a line item if applicable
            if (fullOrderResponse.Tip > 0)
            {
                lineItems.Add(new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "Tip",
                        },
                        UnitAmount = (long)(fullOrderResponse.Tip * 100), // Convert tip to cents
                    },
                    Quantity = 1, // A tip is typically a single item
                });
            }

            // Create the session with line items
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = lineItems, // Set the dynamically created line items
                Mode = "payment",
                SuccessUrl = "http://localhost:3000/PaymentSuccess/" + fullOrderId,
                CancelUrl = "http://localhost:3000/PaymentCancelled/" + fullOrderId,
            };








            var service = new SessionService();
            var session = service.Create(options);

            
            return Ok(new { sessionId = session.Id });

        }
    }

    public class CheckoutSessionRequest
    {
        public string FullOrderId { get; set; }
    }
}
