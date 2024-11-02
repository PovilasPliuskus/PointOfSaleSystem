using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSaleSystem.API.Models.Entities
{
    [Table("CompanyService")]
    public class CompanyServiceEntity : BaseModelEntity
    {
        [Required]
        public Guid fkCompanyId { get; set; }

        [ForeignKey(nameof(fkCompanyId))]
        public CompanyEntity Company { get; set; }
    }
}
