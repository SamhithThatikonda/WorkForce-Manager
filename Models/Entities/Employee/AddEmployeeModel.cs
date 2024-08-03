using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application.Models.Entities.Department;


namespace Application.Models.Entities.Employee
{
public class AddEmployeeModel
{

    [Required]
    [StringLength(100)]
    public string First_Name { get; set; }

    [Required]
    [StringLength(100)]
    public string Last_Name { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal SalaryAmount { get; set; }

    [Required]
    public int Dept_Id { get; set; }
    public DepartmentClass DepartmentObject { get; set; }
}
}