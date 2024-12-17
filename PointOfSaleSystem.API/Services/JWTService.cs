using Microsoft.IdentityModel.Tokens;
using PointOfSaleSystem.API.RequestBodies.JWT;
using PointOfSaleSystem.API.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PointOfSaleSystem.API.Services
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _configuration;

        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(JWTRequest request)
        {
            var secretKey = _configuration["JWTSettings:SecretKey"];
            var expiryDurationMinutes = Convert.ToInt32(_configuration["JWTSettings:ExpiryDurationMinutes"]);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("status", request.Status.ToString()),
                new Claim("employeeId", request.EmployeeId.ToString())
            };

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(expiryDurationMinutes),
                signingCredentials: credentials,
                claims: claims,
                issuer: null,
                audience: null
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

    }
}
