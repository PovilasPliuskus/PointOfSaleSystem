using Microsoft.AspNetCore.Identity.Data;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.ResponseBodies.Login;
using PointOfSaleSystem.API.Services.Interfaces;
using System.Net;

namespace PointOfSaleSystem.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IEmployeeService _employeeService;

        public AuthService(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public LoginResponse Login(RequestBodies.Login.LoginRequest request)
        {
            List<Employee> employees = _employeeService.GetAllEmployees();

            foreach (Employee employee in employees)
            {
                if (employee.LoginUsername == request.Username)
                {
                    if (BCrypt.Net.BCrypt.Verify(request.Password, employee.LoginPasswordHashed))
                    {
                        LoginResponse response = new LoginResponse
                        {
                            StatusCode = HttpStatusCode.OK,
                            EmployeeId = employee.Id,
                            Status = employee.Status
                        };

                        return response;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            LoginResponse badResponse = new LoginResponse
            {
                StatusCode = HttpStatusCode.Unauthorized
            };

            return badResponse;
        }
    }
}
