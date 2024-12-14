using PointOfSaleSystem.API.Models.Enums;

namespace PointOfSaleSystem.API.Models
{
    public class EstablishmentService : BaseModel
    {
        public required decimal Price { get; set; }
        public required CurrencyEnum Currency { get; set; }
        public ICollection<Order>? Orders { get; set; }

    }
}
