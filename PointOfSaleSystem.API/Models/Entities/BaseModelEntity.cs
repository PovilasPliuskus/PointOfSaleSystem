using System.ComponentModel.DataAnnotations;

namespace PointOfSaleSystem.API.Models.Entities
{
    public abstract class BaseModelEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime ReceiveTime { get; set; }

        [Required]
        public DateTime UpdateTime { get; set; }
    }
}
