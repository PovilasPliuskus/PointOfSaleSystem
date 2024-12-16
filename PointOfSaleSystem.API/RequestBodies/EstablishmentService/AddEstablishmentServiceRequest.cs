using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Enums;

namespace PointOfSaleSystem.API.RequestBodies.EstablishmentService
{
    public class AddEstablishmentServiceRequest : BaseModel
    {
        public required decimal Price { get; set; }
        public required CurrencyEnum Currency { get; set; }
        public ICollection<Models.Order>? Orders { get; set; }
        public required Guid fkEstablishmentId { get; set; }
    }
}
