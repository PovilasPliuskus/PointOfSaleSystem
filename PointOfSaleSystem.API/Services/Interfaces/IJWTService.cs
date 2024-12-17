namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface IJWTService
    {
        public string GenerateToken(string username);
    }
}
