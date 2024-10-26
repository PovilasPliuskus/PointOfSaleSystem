using System.ComponentModel.DataAnnotations;

namespace PointOfSaleSystem.API.Models.Entities
{
    public abstract class BaseModelEntity
    {
        [Key]
        public required int Id { get; set; }

        [Required]
        [StringLength(255)]
        public required string Name { get; set; }

        [Required]
        public required DateTime ReceiveTime { get; set; }

        [Required]
        public required DateTime UpdateTime { get; set; }
    }
}
