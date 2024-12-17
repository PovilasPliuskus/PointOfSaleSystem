using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.EstablishmentService;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class EstablishmentServiceController : ControllerBase
    {
        private readonly IEstablishmentServiceService _establishmentServiceService;
        private readonly IUserInfoService _userInfoService;

        public EstablishmentServiceController(IEstablishmentServiceService establishmentServiceService,
            IUserInfoService userInfoService)
        {
            _establishmentServiceService = establishmentServiceService;
            _userInfoService = userInfoService;
        }

        [HttpPost("establishmentService")]
        public async Task<IActionResult> CreateEstablishmentService(AddEstablishmentServiceRequest request)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            _establishmentServiceService.CreateEstablishmentService(request, userInfo);
            return Ok();
        }

        [HttpGet("establishmentService")]
        public async Task<IActionResult> GetEstablishmentServices()
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            List<EstablishmentService> establishmentServices = _establishmentServiceService.GetAllEstablishmnentServices(userInfo);
            return Ok(establishmentServices);
        }

        [HttpGet("establishmentService/{establishmentServiceId}")]
        public async Task<IActionResult> GetEstablishmentService(Guid establishmentServiceId)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            EstablishmentService establishmentService = _establishmentServiceService.GetEstablishmentService(establishmentServiceId, userInfo);
            return Ok(establishmentService);
        }

        [HttpPut("establishmentService/{establishmentServiceId}")]
        public async Task<IActionResult> UpdateEstablishmentService(UpdateEstablishmentServiceRequest request)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            _establishmentServiceService.UpdateEstablishmentService(request, userInfo);
            return Ok();
        }

        [HttpDelete("establishmentService/{establishmentServiceId}")]
        public async Task<IActionResult> DeleteEstablishmentService(Guid establishmentServiceId)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            _establishmentServiceService.DeleteEstablishmentService(establishmentServiceId, userInfo);
            return Ok();
        }
    }
}
