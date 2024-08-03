using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application.Models.Entities.Employee;
using Application.Models.Entities.Salary;


namespace Application.Models.Entities.Department
{
public class AddDeptModel
{
    [Required]
    [StringLength(100)]
    public string Dept_Name { get; set; }
}
}