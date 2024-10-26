using PointOfSaleSystem.API.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSaleSystem.API.Models.Entities
{
    [Table("Employee")]
    public class EmployeeEntity : BaseModelEntity
    {
        [Required]
        [StringLength(255)]
        public required string Surname { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public required decimal Salary { get; set; }

        [Required]
        public required EmployeeStatusEnum Status { get; set; }

        [Required]
        public required int fkEstablishmentId { get; set; }

        [ForeignKey(nameof(fkEstablishmentId))]
        public required EstablishmentEntity Establishment { get; set; }

        [Required]
        [StringLength(50)]
        public required string LoginUsername { get; set; }

        [Required]
        [StringLength(255)]
        public required string LoginPasswordHashed { get; set; }
    }
}
