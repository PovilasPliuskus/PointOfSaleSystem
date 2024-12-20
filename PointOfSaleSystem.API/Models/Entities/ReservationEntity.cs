using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PointOfSaleSystem.API.Models.Enums;

namespace PointOfSaleSystem.API.Models.Entities
{
    [Table("Reservations")]
    public class ReservationEntity : BaseModelEntity
    {
        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public Guid ServiceId { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [Required]
        public ReservationStateEnum Status { get; set; }

        [ForeignKey("ServiceId")]
        public CompanyServiceEntity? Service { get; set; }
    }
}
