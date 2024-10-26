using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSaleSystem.API.Models.Entities
{
    [Table("Establishment")]
    public class EstablishmentEntity : BaseModelEntity
    {
        [Required]
        public required int Code { get; set; }

        [Required]
        public required CompanyEntity Company { get; set; }

        [Required]
        public ICollection<EmployeeEntity>? Employees { get; set; }

        [Required]
        public ICollection<EstablishmentProductEntity>? EstablishmentProducts { get; set; }

        [Required]
        public ICollection<EstablishmentServiceEntity>? EstablishmentServices { get; set; }
    }
}
