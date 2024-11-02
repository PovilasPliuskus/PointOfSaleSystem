﻿using PointOfSaleSystem.API.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSaleSystem.API.Models.Entities
{
    [Table("EstablishmentProduct")]
    public class EstablishmentProductEntity : BaseModelEntity
    {
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public uint AmountInStock { get; set; }

        [Required]
        public CurrencyEnum Currency { get; set; }

        [Required]
        public Guid fkEstablishmentId { get; set; }

        [ForeignKey(nameof(fkEstablishmentId))]
        public EstablishmentEntity Establishment { get; set; }
    }
}