using PointOfSaleSystem.API.Models.Enums;
using PointOfSaleSystem.API.Models;

namespace PointOfSaleSystem.API.RequestBodies.Employee
{
    public class UpdateEmployeeRequest
    {
        public required Guid Id { get; set; }

        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public EmployeeStatusEnum Status { get; set; }
        public Establishment Establishment { get; set; }
        public string LoginUsername { get; set; }
        public string LoginPasswordHashed { get; set; }
    }
}
