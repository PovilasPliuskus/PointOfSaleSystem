using PointOfSaleSystem.API.Models.Enums;

namespace PointOfSaleSystem.API.Models
{
    public class Employee : BaseModel
    {
        public required string Surname { get; set; }
        public required decimal Salary { get; set; }
        public required EmployeeStatusEnum Status { get; set; }
        public required Establishment Establishment { get; set; }
        public required string LoginUsername { get; set; }
        public required string LoginPasswordHashed { get; set; }
    }
}
