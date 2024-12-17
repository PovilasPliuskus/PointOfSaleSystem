using PointOfSaleSystem.API.Models.Enums;

namespace PointOfSaleSystem.API.RequestBodies.JWT
{
    public class JWTRequest
    {
        public required string Username { get; set; }
        public required EmployeeStatusEnum Status { get; set; }
    }
}
