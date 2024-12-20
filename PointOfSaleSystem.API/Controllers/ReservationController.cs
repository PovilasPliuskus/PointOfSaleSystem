using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Models.Enums;
using PointOfSaleSystem.API.Services;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public IActionResult CreateReservation([FromBody] ReservationEntity reservation)
        {
            _reservationService.CreateReservation(reservation);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetReservation(Guid id)
        {
            var reservation = _reservationService.GetReservation(id);
            return Ok(reservation);
        }

        [HttpGet]
        public IActionResult GetAllReservations()
        {
            var reservations = _reservationService.GetAllReservations();
            return Ok(reservations);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReservation(Guid id, [FromBody] ReservationEntity reservation)
        {
            reservation.Id = id;
            _reservationService.UpdateReservation(reservation);
            return Ok();
        }
    }
}
