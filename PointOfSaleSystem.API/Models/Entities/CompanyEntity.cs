using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSaleSystem.API.Models.Entities
{
    [Table("Company")]
    public class CompanyEntity : BaseModelEntity
    {
        [Required]
        [StringLength(100)]
        public string Code { get; set; }
        public ICollection<EstablishmentEntity>? Establishments { get; set; }
        public ICollection<CompanyProductEntity>? CompanyProducts { get; set; }
        public ICollection<CompanyServiceEntity>? CompanyServices { get; set; }
    }
}
