namespace PointOfSaleSystem.API.Models
{
    public class FullOrder : BaseModel
    {
        public required ICollection<Order> Orders { get; set; }
    }
}
