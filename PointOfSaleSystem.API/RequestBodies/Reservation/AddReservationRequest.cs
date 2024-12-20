using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Enums;

namespace PointOfSaleSystem.API.RequestBodies.Reservation
{
    public class AddReservationRequest : BaseModel
    {
        public required Guid CustomerId { get; set; }

        public required Guid ServiceId { get; set; }

        public required DateTime ReservationDate { get; set; }

        public required ReservationStateEnum Status { get; set; }
    }
}
