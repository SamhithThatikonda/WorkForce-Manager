using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application.Models.Entities.Employee;
using Application.Models.Entities.Salary;


namespace Application.Models.Entities.Department
{
public class AddDeptModel
{
    [Required (ErrorMessage = "Please enter Department Name")]
    [StringLength(100)]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
    public string Dept_Name { get; set; }
}
}