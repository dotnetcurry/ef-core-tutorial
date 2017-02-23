using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCore_Scaffolding.Models
{
    public partial class DBEfCoreContext : DbContext
    {
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=DBEfCore;Integrated Security=SSPI;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DeptUniqueId)
                    .HasName("PK_Departments");

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmpUniqueId)
                    .HasName("PK_Employees");

                entity.HasIndex(e => e.DeptUniqueId)
                    .HasName("IX_Employees_DeptUniqueId");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EmpFirstName)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.EmpLastName).HasMaxLength(80);

                entity.HasOne(d => d.DeptUnique)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DeptUniqueId);
            });
        }
    }
}