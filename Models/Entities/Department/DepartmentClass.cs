using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application.Models.Entities.Employee;
using Application.Models.Entities.Salary;

namespace Application.Models.Entities.Department
{
public class DepartmentClass
{
    [Key]
    public int Dept_Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Dept_Name { get; set; }
}
}