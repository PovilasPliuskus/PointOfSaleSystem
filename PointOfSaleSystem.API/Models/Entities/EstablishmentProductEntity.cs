using PointOfSaleSystem.API.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSaleSystem.API.Models.Entities
{
    [Table("EstablishmentProduct")]
    public class EstablishmentProductEntity : BaseModelEntity
    {
        [Required]
        public required decimal Price { get; set; }

        [Required]
        public required uint AmountInStock { get; set; }

        [Required]
        public required CurrencyEnum Currency { get; set; }

        [Required]
        public required EstablishmentEntity Establishment { get; set; }
    }
}
