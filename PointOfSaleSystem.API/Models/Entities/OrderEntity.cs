using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSaleSystem.API.Models.Entities
{
    [Table("Order")]
    public class OrderEntity : BaseModelEntity
    {
        public Guid? fkEstablishmentProduct { get; set; }

        [ForeignKey(nameof(fkEstablishmentProduct))]
        public EstablishmentProductEntity EstablishmentProduct { get; set; }

        public Guid? fkEstablishmentService { get; set; }

        [ForeignKey(nameof(fkEstablishmentService))]
        public EstablishmentServiceEntity EstablishmentService { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public Guid fkFullOrderId { get; set; }

        [ForeignKey(nameof(fkFullOrderId))]
        public FullOrderEntity FullOrder { get; set; }
    }
}
