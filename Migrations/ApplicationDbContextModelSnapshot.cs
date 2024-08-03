﻿// <auto-generated />
using Application.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Application.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Application.Models.Entities.Auth.AuthClass", b =>
                {
                    b.Property<int>("Emp_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Emp_Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Emp_Id");

                    b.ToTable("AuthTable", (string)null);
                });

            modelBuilder.Entity("Application.Models.Entities.Department.DepartmentClass", b =>
                {
                    b.Property<int>("Dept_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Dept_Id"));

                    b.Property<string>("Dept_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Dept_Id");

                    b.ToTable("DepartmentTable", (string)null);
                });

            modelBuilder.Entity("Application.Models.Entities.Employee.EmployeeClass", b =>
                {
                    b.Property<int>("Emp_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Emp_Id"));

                    b.Property<int>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Emp_Id");

                    b.HasIndex("Dept_Id");

                    b.ToTable("EmployeeTable", (string)null);
                });

            modelBuilder.Entity("Application.Models.Entities.Salary.SalaryClass", b =>
                {
                    b.Property<int>("Sal_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Sal_Id"));

                    b.Property<int>("Emp_Id")
                        .HasColumnType("int");

                    b.Property<decimal>("SalaryAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Sal_Id");

                    b.HasIndex("Emp_Id");

                    b.ToTable("SalaryTable", (string)null);
                });

            modelBuilder.Entity("Application.Models.Entities.Employee.EmployeeClass", b =>
                {
                    b.HasOne("Application.Models.Entities.Department.DepartmentClass", "DepartmentObject")
                        .WithMany()
                        .HasForeignKey("Dept_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DepartmentObject");
                });

            modelBuilder.Entity("Application.Models.Entities.Salary.SalaryClass", b =>
                {
                    b.HasOne("Application.Models.Entities.Employee.EmployeeClass", "EmployeeObject")
                        .WithMany()
                        .HasForeignKey("Emp_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeObject");
                });
#pragma warning restore 612, 618
        }
    }
}
