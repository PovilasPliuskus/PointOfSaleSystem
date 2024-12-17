using System.Security.Claims;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface IUserInfoService
    {
        public string GetEmployeeStatus(ClaimsPrincipal user);
        public string GetEmployeeId(ClaimsPrincipal user);
    }
}
