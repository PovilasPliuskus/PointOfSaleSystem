using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSaleSystem.API.Models.Entities
{
    [Table("CompanyService")]
    public class CompanyServiceEntity : BaseModelEntity
    {
        [Required]
        public required int fkCompanyId { get; set; }

        [ForeignKey(nameof(fkCompanyId))]
        public required CompanyEntity Company { get; set; }
    }
}
