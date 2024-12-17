using PointOfSaleSystem.API.Models.Enums;

namespace PointOfSaleSystem.API.Models
{
    public class Tax : BaseModel
    {
        public float amount; // fraction, not percentage
    }
}
