using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Services.Interfaces;
using PointOfSaleSystem.API.RequestBodies.Employees;
using Microsoft.AspNetCore.Authorization;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using Serilog;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IUserInfoService _userInfoService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService employeeService,
            IUserInfoService userInfoService,
            ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _userInfoService = userInfoService;
            _logger = logger;
        }

        [HttpPost("employee")]
        public async Task<IActionResult> CreateEmployee(AddEmployeeRequest request)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            try
            {
                _employeeService.CreateEmployee(request, userInfo);
                _logger.LogInformation("Successfully created employee by user {UserId}", userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create employee by user {UserId}", userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("employee")]
        public async Task<IActionResult> GetEmployees()
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            try
            {
                List<Employee> employees = _employeeService.GetAllEmployees(userInfo);
                _logger.LogInformation("Successfully retrieved employees by user {UserId}", userInfo.Id);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve employees by user {UserId}", userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("employee/{employeeID}")]
        public async Task<IActionResult> GetEmployee(Guid employeeID)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            try
            {
                Employee employee = _employeeService.GetEmployee(employeeID, userInfo);
                _logger.LogInformation("Successfully retrieved employee {EmployeeID} by user {UserId}", employeeID, userInfo.Id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve employee {EmployeeID} by user {UserId}", employeeID, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("employee/{employeeID}")]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeRequest request)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            try
            {
                _employeeService.UpdateEmployee(request, userInfo);
                _logger.LogInformation("Successfully updated employee {EmployeeID} by user {UserId}", request.Id, userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update employee {EmployeeID} by user {UserId}", request.Id, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("employee/{employeeID}")]
        public async Task<IActionResult> DeleteEmployee(Guid employeeID)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            try
            {
                _employeeService.DeleteEmployee(employeeID, userInfo);
                _logger.LogInformation("Successfully deleted employee {EmployeeID} by user {UserId}", employeeID, userInfo.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete employee {EmployeeID} by user {UserId}", employeeID, userInfo.Id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}