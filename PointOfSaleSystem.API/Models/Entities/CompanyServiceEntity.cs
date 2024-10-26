using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSaleSystem.API.Models.Entities
{
    [Table("CompanyService")]
    public class CompanyServiceEntity : BaseModelEntity
    {
        [Required]
        public CompanyEntity Company { get; set; }
    }
}
