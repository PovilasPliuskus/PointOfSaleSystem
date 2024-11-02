namespace PointOfSaleSystem.API.Models
{
    public abstract class BaseModel
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required DateTime ReceiveTime { get; set; }
        public required DateTime UpdateTime { get; set; }
        public required Guid CreatedByEmployeeId { get; set; }
        public required Guid ModifiedByEmployeeId { get; set; }
    }
}
