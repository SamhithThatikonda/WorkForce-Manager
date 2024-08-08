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


    [StringLength(200)]
    [Required (ErrorMessage = "Please enter a valid First Name")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
    public string First_Name { get; set; }

    [Required (ErrorMessage = "Please enter a valid Last Name")]
    [StringLength(200)]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
    public string Last_Name { get; set; }

    [ForeignKey("Department")]
    public int Dept_Id { get; set; }
    public DepartmentClass DepartmentObject { get; set; }
}
}