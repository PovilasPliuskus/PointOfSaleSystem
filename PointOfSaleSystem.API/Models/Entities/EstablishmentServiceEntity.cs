﻿using PointOfSaleSystem.API.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSaleSystem.API.Models.Entities
{
    [Table("EstablishmentService")]
    public class EstablishmentServiceEntity : BaseModelEntity
    {
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public CurrencyEnum Currency { get; set; }

        [Required]
        public EstablishmentEntity Establishment { get; set; }
    }
}
