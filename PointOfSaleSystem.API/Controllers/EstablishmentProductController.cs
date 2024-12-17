using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.EstablishmentProduct;
using PointOfSaleSystem.API.RequestBodies.UserInfo;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class EstablishmentProductController : ControllerBase
    {
        private readonly IEstablishmentProductService _establishmentProductService;
        private readonly IUserInfoService _userInfoService;

        public EstablishmentProductController(IEstablishmentProductService establishmentProductService,
            IUserInfoService userInfoService)
        {
            _establishmentProductService = establishmentProductService;
            _userInfoService = userInfoService;
        }

        [HttpPost("establishmentProduct")]
        public async Task<IActionResult> CreateEstablishmentProduct(AddEstablishmentProductRequest request)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            _establishmentProductService.CreateEstablishmentProduct(request, userInfo);
            return Ok();
        }

        [HttpGet("establishmentProduct")]
        public async Task<IActionResult> GetEstablishmentProducts()
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            List<EstablishmentProduct> establishmentProducts = _establishmentProductService.GetAllEstablishmentProducts(userInfo);
            return Ok(establishmentProducts);
        }

        [HttpGet("establishmentProduct/{establishmentProductId}")]
        public async Task<IActionResult> GetEstablishmentProduct(Guid establishmentProductId)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            EstablishmentProduct establishmentProduct = _establishmentProductService.GetEstablishmentProduct(establishmentProductId, userInfo);
            return Ok(establishmentProduct);
        }

        [HttpPut("establishmentProduct/{establishmentProductId}")]
        public async Task<IActionResult> UpdateEstablishmentProduct(UpdateEstablishmentProductRequest request)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            _establishmentProductService.UpdateEstablishmentProduct(request, userInfo);
            return Ok();
        }

        [HttpDelete("establishmentProduct/{establishmentProductId}")]
        public async Task<IActionResult> DeleteEstablishmentProduct(Guid establishmentProductId)
        {
            string status = _userInfoService.GetEmployeeStatus(User);
            string employeeId = _userInfoService.GetEmployeeId(User);

            var userInfo = new UserInfo
            {
                Status = status,
                Id = employeeId
            };

            _establishmentProductService.DeleteEstablishmentProduct(establishmentProductId, userInfo);
            return Ok();
        }
    }
}
