using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.RequestBodies.JWT;
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
        private readonly IJWTService _jwtService;

        public AuthController(IConfiguration configuration,
            IAuthService authService,
            IJWTService jwtService)
        {
            _configuration = configuration;
            _authService = authService;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(RequestBodies.Login.LoginRequest request)
        {
            var response = _authService.Login(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jwtRequest = new JWTRequest
                {
                    Username = request.Username,
                    Status = response.Status,
                    EmployeeId = response.EmployeeId,
                };

                var token = _jwtService.GenerateToken(jwtRequest);
                return Ok(new { token, response.EmployeeId });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
