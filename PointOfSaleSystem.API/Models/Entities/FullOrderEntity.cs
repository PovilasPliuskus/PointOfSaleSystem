using PointOfSaleSystem.API.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSaleSystem.API.Models.Entities
{
    [Table("FullOrder")]
    public class FullOrderEntity : BaseModelEntity
    {
        [Required]
        public ICollection<OrderEntity> Orders { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Tip { get; set; }

        [Required]
        public OrderStatusEnum Status { get; set; }
    }
}
