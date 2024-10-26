namespace PointOfSaleSystem.API.Models
{
    public abstract class BaseModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required DateTime ReceiveTime { get; set; }
        public required DateTime UpdateTime { get; set; }
    }
}
