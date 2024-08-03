using Microsoft.EntityFrameworkCore;
using Application.Models.Entities;
using Application.Models.Entities.Employee;
using Application.Models.Entities.Salary;
using Application.Models.Entities.Department;

namespace Application.Data
{
    public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<EmployeeClass> Employees { get; set; }
    public DbSet<SalaryClass> Salaries { get; set; }
    public DbSet<DepartmentClass> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Employee entity
        modelBuilder.Entity<EmployeeClass>(entity =>
        {
            entity.HasKey(e => e.Emp_Id);
            entity.Property(e => e.First_Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Last_Name).IsRequired().HasMaxLength(100);
            entity.HasOne(e => e.DepartmentObject)
                  .WithMany()
                  .HasForeignKey(e => e.Dept_Id);
            entity.ToTable("EmployeeTable");
        });

        // Configure Salary entity
        modelBuilder.Entity<SalaryClass>(entity =>
        {
            entity.HasKey(s => s.Sal_Id);
            entity.Property(s => s.SalaryAmount).IsRequired().HasColumnType("decimal(18, 2)");
            entity.HasOne(s => s.EmployeeObject)
                  .WithMany()
                  .HasForeignKey(s => s.Emp_Id);
            entity.ToTable("SalaryTable");
        });

        // Configure Department entity
        modelBuilder.Entity<DepartmentClass>(entity =>
        {
            entity.HasKey(d => d.Dept_Id);
            entity.Property(d => d.Dept_Name).IsRequired().HasMaxLength(100);
            entity.ToTable("DepartmentTable");
        });
    }
}
}