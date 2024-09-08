using HealthcareRecordsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthcareRecordsAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Конфигурация для Section
            modelBuilder.Entity<Section>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Section>()
                .Property(s => s.Number)
                .HasMaxLength(50) 
                .IsRequired();

            modelBuilder.Entity<Section>()
                .HasMany(s => s.Patients)
                .WithOne(p => p.Section)
                .HasForeignKey(p => p.SectionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Section>()
                .HasMany(s => s.Doctors)
                .WithOne(d => d.Section)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.SetNull);
            #endregion


            #region Конфигурация для Specialization
            modelBuilder.Entity<Specialization>()
                .HasKey(sp => sp.Id);

            modelBuilder.Entity<Specialization>()
                .Property(sp => sp.Name)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Specialization>()
                .HasMany(sp => sp.Doctors)
                .WithOne(d => d.Specialization)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion


            #region Конфигурация для Cabinet
            modelBuilder.Entity<Cabinet>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Cabinet>()
                .Property(c => c.Number)
                .HasMaxLength(10) 
                .IsRequired();

            modelBuilder.Entity<Cabinet>()
                .HasMany(c => c.Doctors)
                .WithOne(d => d.Cabinet)
                .HasForeignKey(d => d.CabinetId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion


            #region Конфигурация для Patient
            modelBuilder.Entity<Patient>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Patient>()
                .Property(p => p.LastName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Patient>()
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Patient>()
                .Property(p => p.MiddleName)
                .HasMaxLength(50);

            modelBuilder.Entity<Patient>()
                .Property(p => p.Address)
                .HasMaxLength(200);

            modelBuilder.Entity<Patient>()
                .Property(p => p.BirthDate)
                .IsRequired();

            modelBuilder.Entity<Patient>()
                .Property(p => p.Gender)
                .HasMaxLength(3);
            #endregion

            #region Конфигурация для Doctor
            modelBuilder.Entity<Doctor>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Doctor>()
                .Property(d => d.CabinetId)
                .IsRequired(false);

            modelBuilder.Entity<Doctor>()
                .Property(d => d.FullName)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Cabinet)
                .WithMany(c => c.Doctors)
                .HasForeignKey(d => d.CabinetId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Specialization)
                .WithMany(sp => sp.Doctors)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Section)
                .WithMany(s => s.Doctors)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.SetNull);
            #endregion
        }
    }
}
