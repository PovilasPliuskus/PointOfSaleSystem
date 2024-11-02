using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSaleSystem.API.Models.Entities
{
    public abstract class BaseModelEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime ReceiveTime { get; set; }

        [Required]
        public DateTime UpdateTime { get; set; }

        [Required]
        public Guid? fkCreatedByEmployee { get; set; }

        [ForeignKey(nameof(fkCreatedByEmployee))]
        public EmployeeEntity CreatedByEmployee { get; set; }

        [Required]
        public Guid? fkModifiedByEmployee { get; set; }

        [ForeignKey(nameof(fkModifiedByEmployee))]
        public EmployeeEntity UpdatedByEmployee { get; set; }
    }
}
