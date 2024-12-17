using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Services.Interfaces;
using System.Net;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration configuration,
            IAuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(RequestBodies.Login.LoginRequest request)
        {
            var response = _authService.Login(request);
            if (response == HttpStatusCode.OK)
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
