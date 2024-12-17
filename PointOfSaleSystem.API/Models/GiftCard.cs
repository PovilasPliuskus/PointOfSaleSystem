using PointOfSaleSystem.API.Models.Enums;

namespace PointOfSaleSystem.API.Models
{
    public class GiftCard : BaseModel
    {
        public CurrencyEnum Currency { get; set; }
        public float amount; // percentage if tax, sum if 
    }
}
