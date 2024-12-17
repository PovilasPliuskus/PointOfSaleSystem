using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Services.Interfaces;
using PointOfSaleSystem.API.RequestBodies.Employees;
using Microsoft.AspNetCore.Authorization;
using PointOfSaleSystem.API.RequestBodies.UserInfo;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IUserInfoService _userInfoService;

        public EmployeeController(IEmployeeService employeeService,
            IUserInfoService userInfoService)
        {
            _employeeService = employeeService;
            _userInfoService = userInfoService;
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

            _employeeService.CreateEmployee(request, userInfo);
            return Ok();
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

            List<Employee> employees = _employeeService.GetAllEmployees(userInfo);
            return Ok(employees);
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

            Employee employee = _employeeService.GetEmployee(employeeID, userInfo);
            return Ok(employee);
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

            _employeeService.UpdateEmployee(request, userInfo);
            return Ok();
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

            _employeeService.DeleteEmployee(employeeID, userInfo);
            return Ok();
        }
    }
}