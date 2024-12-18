using PointOfSaleSystem.API.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSaleSystem.API.Models.Entities
{
    [Table("Tax")]
    public class TaxEntity : BaseModelEntity
    {
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal amount { get; set; }

        [Required]
        public Guid fkTaxFullOrderId { get; set; }

        [ForeignKey(nameof(fkTaxFullOrderId))]
        public FullOrderEntity FullOrder { get; set; }
    }
}
