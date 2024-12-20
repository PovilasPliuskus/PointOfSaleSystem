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
        public DbSet<ReservationEntity> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstablishmentEntity>()
                .HasOne(e => e.Company)
                .WithMany(com => com.Establishments)
                .HasForeignKey(e => e.fkCompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CompanyProductEntity>()
                .HasOne(cp => cp.Company)
                .WithMany(com => com.CompanyProducts)
                .HasForeignKey(cp => cp.fkCompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CompanyServiceEntity>()
                .HasOne(cs => cs.Company)
                .WithMany(com => com.CompanyServices)
                .HasForeignKey(cs => cs.fkCompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EstablishmentProductEntity>()
                .HasOne(ep => ep.Establishment)
                .WithMany(e => e.EstablishmentProducts)
                .HasForeignKey(ep => ep.fkEstablishmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EstablishmentServiceEntity>()
                .HasOne(es => es.Establishment)
                .WithMany(e => e.EstablishmentServices)
                .HasForeignKey(es => es.fkEstablishmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmployeeEntity>()
                .HasOne(e => e.Establishment)
                .WithMany(est => est.Employees)
                .HasForeignKey(e => e.fkEstablishmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderEntity>()
                .HasOne(o => o.EstablishmentService)
                .WithMany(es => es.Orders)
                .HasForeignKey(o => o.fkEstablishmentService)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderEntity>()
                .HasOne(o => o.EstablishmentProduct)
                .WithMany(ep => ep.Orders)
                .HasForeignKey(o => o.fkEstablishmentProduct)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderEntity>()
                .HasOne(o => o.FullOrder)
                .WithMany(fo => fo.Orders)
                .HasForeignKey(o => o.fkFullOrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FullOrderEntity>()
                .HasOne(fo => fo.Establishment)
                .WithMany(e => e.FullOrders)
                .HasForeignKey(fo => fo.fkEstablishmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
