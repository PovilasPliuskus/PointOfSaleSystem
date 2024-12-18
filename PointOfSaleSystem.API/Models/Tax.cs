using PointOfSaleSystem.API.Models.Enums;

namespace PointOfSaleSystem.API.Models
{
    public class Tax : BaseModel
    {
        public decimal amount { get; set; } // fraction, not percentage
    }
}
