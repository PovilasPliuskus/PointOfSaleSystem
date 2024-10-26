using PointOfSaleSystem.API.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSaleSystem.API.Models.Entities
{
    [Table("EstablishmentProduct")]
    public class EstablishmentProductEntity : BaseModelEntity
    {
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public uint AmountInStock { get; set; }

        [Required]
        public required CurrencyEnum Currency { get; set; }

        [Required]
        public required EstablishmentEntity Establishment { get; set; }
    }
}
