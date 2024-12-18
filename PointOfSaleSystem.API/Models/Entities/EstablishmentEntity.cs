using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSaleSystem.API.Models.Entities
{
    [Table("Establishment")]
    public class EstablishmentEntity : BaseModelEntity
    {
        [Required]
        [StringLength(100)]
        public string Code { get; set; }

        [Required]
        public Guid fkCompanyId { get; set; }

        [ForeignKey(nameof(fkCompanyId))]
        public CompanyEntity Company { get; set; }

        [Required]
        public ICollection<EmployeeEntity>? Employees { get; set; }

        [Required]
        public ICollection<EstablishmentProductEntity>? EstablishmentProducts { get; set; }

        [Required]
        public ICollection<EstablishmentServiceEntity>? EstablishmentServices { get; set; }

        [Required]
        public ICollection<FullOrderEntity>? FullOrders { get; set; }
    }
}
