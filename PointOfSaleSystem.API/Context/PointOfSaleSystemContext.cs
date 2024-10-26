using Microsoft.EntityFrameworkCore;
using PointOfSaleSystem.API.Models.Entities;

namespace PointOfSaleSystem.API.Context
{
    public class PointOfSaleSystemContext : DbContext
    {
        public PointOfSaleSystemContext(DbContextOptions<PointOfSaleSystemContext> options)
            : base(options)
        {

        }

        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<CompanyProductEntity> CompanyProducts { get; set; }
        public DbSet<CompanyServiceEntity> CompanyServices { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<EstablishmentEntity> Establishments { get; set; }
        public DbSet<EstablishmentProductEntity> EstablishmentProducts { get; set; }
        public DbSet<EstablishmentServiceEntity> EstablishmentServices { get; set; }
        public DbSet<FullOrderEntity> FullOrders { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }

    }
}
