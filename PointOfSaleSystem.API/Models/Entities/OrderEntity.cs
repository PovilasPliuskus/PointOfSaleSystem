using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSaleSystem.API.Models.Entities
{
    [Table("Order")]
    public class OrderEntity : BaseModelEntity
    {
        [Required]
        public ICollection<EstablishmentProductEntity>? EstablishmentProducts { get; set; }

        [Required]
        public ICollection<EstablishmentServiceEntity>? EstablishmentServices { get; set; }

        [Required]
        public Guid fkFullOrder {  get; set; }

        [ForeignKey(nameof(fkFullOrder))]
        public FullOrderEntity FullOrder { get; set; }
    }
}
