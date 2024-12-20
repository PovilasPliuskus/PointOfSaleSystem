﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSaleSystem.API.Models.Entities
{
    [Table("CompanyProduct")]
    public class CompanyProductEntity : BaseModelEntity
    {
        [Required]
        public bool AlcoholicBeverage { get; set; }

        [Required]
        public Guid fkCompanyId { get; set; }

        [ForeignKey(nameof(fkCompanyId))]
        public CompanyEntity Company { get; set; }
    }
}
