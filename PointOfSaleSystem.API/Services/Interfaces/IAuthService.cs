using Microsoft.AspNetCore.Identity.Data;
using PointOfSaleSystem.API.ResponseBodies.Login;
using System.Net;

namespace PointOfSaleSystem.API.Services.Interfaces
{
    public interface IAuthService
    {
        public LoginResponse Login(RequestBodies.Login.LoginRequest request);
    }
}
