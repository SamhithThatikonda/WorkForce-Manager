using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application.Models.Entities.Employee;
using Application.Models.Entities.Department;

namespace Application.Models.Entities.Salary
{
    public class SalaryClass
{
    [Key]
    public int Sal_Id { get; set; }

    [ForeignKey("Employee")]
    public int Emp_Id { get; set; }
    public EmployeeClass EmployeeObject { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    // [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "Invalid Salary Amount")]
    // [Range(0, 1000000)]
    public decimal SalaryAmount { get; set; }

    public string timestamp { get; set; }
}
}