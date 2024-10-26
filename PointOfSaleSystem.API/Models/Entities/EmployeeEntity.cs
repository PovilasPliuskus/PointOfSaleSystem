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
        public string Surname { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }

        [Required]
        public EmployeeStatusEnum Status { get; set; }

        [Required]
        public Guid fkEstablishmentId { get; set; }

        [ForeignKey(nameof(fkEstablishmentId))]
        public EstablishmentEntity Establishment { get; set; }

        [Required]
        [StringLength(50)]
        public string LoginUsername { get; set; }

        [Required]
        [StringLength(255)]
        public string LoginPasswordHashed { get; set; }
    }
}
