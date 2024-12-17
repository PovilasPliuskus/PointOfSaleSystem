using Microsoft.AspNetCore.Identity.Data;
using System.Net;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface IAuthService
    {
        public HttpStatusCode Login(RequestBodies.Login.LoginRequest request);
    }
}
