using PointOfSaleSystem.API.Services.Interfaces;
using System.Security.Claims;

namespace PointOfSaleSystem.API.Services
{
    public class UserInfoService : IUserInfoService
    {
        public string GetEmployeeStatus(ClaimsPrincipal user)
        {
            var statusClaim = user.Claims.FirstOrDefault(c => c.Type == "status");
            return statusClaim.Value;
        }

        public string GetEmployeeId(ClaimsPrincipal user)
        {
            var employeeIdClaim = user.Claims.FirstOrDefault(c => c.Type == "employeeId");
            return employeeIdClaim.Value;
        }
    }
}
