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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FullOrderEntity>()
                .HasKey(fo => new { fo.Id, fo.fkOrderId });

            modelBuilder.Entity<EstablishmentEntity>()
                .HasOne(e => e.Company)
                .WithMany(com => com.Establishments)
                .HasForeignKey(e => e.fkCompanyId);

            modelBuilder.Entity<CompanyProductEntity>()
                .HasOne(cp => cp.Company)
                .WithMany(com => com.CompanyProducts)
                .HasForeignKey(cp => cp.fkCompanyId);

            modelBuilder.Entity<CompanyServiceEntity>()
                .HasOne(cs => cs.Company)
                .WithMany(com => com.CompanyServices)
                .HasForeignKey(cs => cs.fkCompanyId);

            modelBuilder.Entity<EstablishmentProductEntity>()
                .HasOne(ep => ep.Establishment)
                .WithMany(e => e.EstablishmentProducts)
                .HasForeignKey(ep => ep.fkEstablishmentId);

            modelBuilder.Entity<EstablishmentServiceEntity>()
                .HasOne(es => es.Establishment)
                .WithMany(e => e.EstablishmentServices)
                .HasForeignKey(es => es.fkEstablishmentId);

            modelBuilder.Entity<EmployeeEntity>()
                .HasOne(e => e.Establishment)
                .WithMany(est => est.Employees)
                .HasForeignKey(e => e.fkEstablishmentId);
        }
    }
}
