using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFCoreApp;

namespace EFCoreApp.Migrations
{
    [DbContext(typeof(CompanyEntities))]
    partial class CompanyEntitiesModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreApp.Department", b =>
                {
                    b.Property<int>("DeptUniqueId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Capacity");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("DeptNo");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("DeptUniqueId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EFCoreApp.Employee", b =>
                {
                    b.Property<int>("EmpUniqueId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DeptUniqueId");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("EmpFirstName")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("EmpLastName")
                        .HasMaxLength(80);

                    b.Property<int>("EmpNo");

                    b.Property<int>("Salary");

                    b.HasKey("EmpUniqueId");

                    b.HasIndex("DeptUniqueId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EFCoreApp.Employee", b =>
                {
                    b.HasOne("EFCoreApp.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DeptUniqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
