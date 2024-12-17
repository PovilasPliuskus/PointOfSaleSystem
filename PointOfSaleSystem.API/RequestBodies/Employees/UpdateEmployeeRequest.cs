namespace PointOfSaleSystem.API.RequestBodies.Employees
{
    public class UpdateEmployeeRequest
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required decimal Salary { get; set; }
        public required int Status { get; set; }
        public required string LoginUsername { get; set; }
        public required string LoginPasswordHashed { get; set; }
        public required DateTime UpdateTime { get; set; }
    }
}
