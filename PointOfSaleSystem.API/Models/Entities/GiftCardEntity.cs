using PointOfSaleSystem.API.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSaleSystem.API.Models.Entities
{
    [Table("GiftCard")]
    public class GiftCardEntity : BaseModelEntity
    {
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal amount { get; set; }
        [Required]
        public CurrencyEnum currency { get; set; }

        [Required]
        public Guid fkGiftFullOrderId { get; set; }

        [ForeignKey(nameof(fkGiftFullOrderId))]
        public FullOrderEntity FullOrder { get; set; }
    }
}
