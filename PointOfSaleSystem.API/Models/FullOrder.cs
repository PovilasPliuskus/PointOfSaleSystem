namespace PointOfSaleSystem.API.Models
{
    public class FullOrder
    {
        public int Id { get; set; }
        public required ICollection<Order> Orders { get; set; }
    }
}
