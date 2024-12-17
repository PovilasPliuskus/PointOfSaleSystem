using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Enums;

namespace PointOfSaleSystem.API.RequestBodies.Employees
{
    public class AddEmployeeRequest : BaseModel
    {
        public required string Surname { get; set; }
        public required decimal Salary { get; set; }
        public required EmployeeStatusEnum Status { get; set; }
        public required string LoginUsername { get; set; }
        public required string LoginPasswordHashed { get; set; }
        public required Guid fkEstablishmentId { get; set; }
    }
}
