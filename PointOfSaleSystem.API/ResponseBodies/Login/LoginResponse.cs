using PointOfSaleSystem.API.Models.Enums;
using System.Net;

namespace PointOfSaleSystem.API.ResponseBodies.Login
{
    public class LoginResponse
    {
        public required HttpStatusCode StatusCode;
        public Guid EmployeeId;
        public EmployeeStatusEnum Status;
    }
}
