using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Company;
using PointOfSaleSystem.API.Services.Interfaces;
using PointOfSaleSystem.API.RequestBodies.Employee;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("employee")]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            _employeeService.CreateEmployee(employee);
            return Ok();
        }

        [HttpGet("employee")]
        public async Task<IActionResult> GetEmployees()
        {
            List<Employee> employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("employee/{employeeID}")]
        public async Task<IActionResult> GetEmployee(Guid employeeID)
        {
            Employee employee = _employeeService.GetEmployee(employeeID);
            return Ok(company);
        }

        [HttpPut("employee/{employeeID}")]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeRequest request)
        {
            _employeeService.UpdateEmployee(request);
            return Ok();
        }

        [HttpDelete("employee/{employeeID}")]
        public async Task<IActionResult> DeleteEmployee(Guid employeeID)
        {
            _employeeService.DeleteEmployee(employeeID);
            return Ok();
        }
    }
}
