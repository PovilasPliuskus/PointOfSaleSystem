using PointOfSaleSystem.API.Models.Enums;

namespace PointOfSaleSystem.API.Models
{
    public class Reservation : BaseModel
    {
        public Guid CustomerId { get; set; }
        public Guid ServiceId { get; set; }
        public DateTime ReservationDate { get; set; }
        public ReservationStateEnum Status { get; set; }

        public CompanyService? Service { get; set; }
    }
}