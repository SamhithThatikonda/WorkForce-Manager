using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models.Entities
{
    public class Salary
{
    [Key]
    public int Sal_Id { get; set; }

    [ForeignKey("Employee")]
    public int Emp_Id { get; set; }
    public Employee EmployeeObject { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal SalaryAmount { get; set; }
}
}