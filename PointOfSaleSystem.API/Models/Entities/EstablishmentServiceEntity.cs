using PointOfSaleSystem.API.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSaleSystem.API.Models.Entities
{
    [Table("EstablishmentService")]
    public class EstablishmentServiceEntity : BaseModelEntity
    {
        [Required]
        public required decimal Price { get; set; }

        [Required]
        public required CurrencyEnum Currency { get; set; }

        [Required]
        public required int fkEstablishmentId { get; set; }

        [ForeignKey(nameof(fkEstablishmentId))]
        public required EstablishmentEntity Establishment { get; set; }
    }
}
