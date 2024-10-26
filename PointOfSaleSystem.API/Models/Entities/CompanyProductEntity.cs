﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSaleSystem.API.Models.Entities
{
    [Table("CompanyProduct")]
    public class CompanyProductEntity : BaseModelEntity
    {
        [Required]
        public required bool AlcoholicBeverage { get; set; }

        [Required]
        public required int fkCompanyId { get; set; }

        [ForeignKey(nameof(fkCompanyId))]
        public required CompanyEntity Company { get; set; }
    }
}
