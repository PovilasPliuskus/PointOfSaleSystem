using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Establishment;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.Services;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class EstablishmentController : ControllerBase
    {
        private readonly IEstablishmentService _establishmentService;
        private readonly IUserInfoService _userInfoService;

        public EstablishmentController(IEstablishmentService establishmentService,
            IUserInfoService userInfoService)
        {
            _establishmentService = establishmentService;
            _userInfoService = userInfoService;
        }

        [HttpPost("establishment")]
        public async Task<IActionResult> CreateEstablishment(AddEstablishmentRequest establishment)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            _establishmentService.CreateEstablishment(establishment, userInfo);
            return Ok();
        }

        [HttpGet("establishment")]
        public async Task<IActionResult> GetEstablishments()
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            List<Establishment> establishments = _establishmentService.GetAllEstablishments(userInfo);
            return Ok(establishments);
        }

        [HttpGet("establishment/{establishmentId}")]
        public async Task<IActionResult> GetEstablishment(Guid establishmentId)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            Establishment establishment = _establishmentService.GetEstablishment(establishmentId, userInfo);
            return Ok(establishment);
        }

        [HttpPut("establishment/{establishmentId}")]
        public async Task<IActionResult> UpdateEstablishment(UpdateEstablishmentRequest request)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            _establishmentService.UpdateEstablishment(request, userInfo);
            return Ok();
        }

        [HttpDelete("establishment/{establishmentId}")]
        public async Task<IActionResult> DeleteEstablishment(Guid establishmentId)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            _establishmentService.DeleteEstablishment(establishmentId, userInfo);
            return Ok();
        }
    }
}