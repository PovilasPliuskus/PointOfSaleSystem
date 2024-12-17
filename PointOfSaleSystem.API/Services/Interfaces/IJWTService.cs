using PointOfSaleSystem.API.RequestBodies.JWT;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface IJWTService
    {
        public string GenerateToken(JWTRequest request);
    }
}
