using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSaleSystem.API.Models.Entities
{
    [Table("FullOrder")]
    public class FullOrderEntity : BaseModelEntity
    {
        [Required]
        public ICollection<OrderEntity> Orders { get; set; }
    }
}
