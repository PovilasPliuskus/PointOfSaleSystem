using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.RequestBodies.JWT;
using PointOfSaleSystem.API.Services.Interfaces;
using System.Net;
using Serilog;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;
        private readonly IJWTService _jwtService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IConfiguration configuration,
            IAuthService authService,
            IJWTService jwtService,
            ILogger<AuthController> logger)
        {
            _configuration = configuration;
            _authService = authService;
            _jwtService = jwtService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(RequestBodies.Login.LoginRequest request)
        {
            _logger.LogInformation("Login attempt for user {Username}", request.Username);

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
                _logger.LogInformation("Login successful for user {Username}", request.Username);
                return Ok(new { token, response.EmployeeId });
            }
            else
            {
                _logger.LogWarning("Login failed for user {Username}", request.Username);
                return Unauthorized();
            }
        }
    }
}
