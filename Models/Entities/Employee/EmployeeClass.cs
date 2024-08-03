using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application.Models.Entities.Department;
using Application.Models.Entities.Salary;

namespace Application.Models.Entities.Employee
{
public class EmployeeClass
{
    [Key]
    public int Emp_Id { get; set; }

    [Required]
    [StringLength(100)]
    public string First_Name { get; set; }

    [Required]
    [StringLength(100)]
    public string Last_Name { get; set; }

    [ForeignKey("Department")]
    public int Dept_Id { get; set; }
    public DepartmentClass DepartmentObject { get; set; }
}
}