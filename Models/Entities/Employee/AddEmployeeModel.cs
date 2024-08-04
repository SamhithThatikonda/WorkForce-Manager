using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application.Models.Entities.Department;


namespace Application.Models.Entities.Employee
{
public class AddEmployeeModel
{

    [Required (ErrorMessage = "Please enter a valid First Name")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
    [StringLength(100)]
    public string First_Name { get; set; }

    [Required (ErrorMessage = "Please enter a valid Last Name")]
    [StringLength(100)]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]

    public string Last_Name { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    [Range(0, 1000000)]
    public decimal SalaryAmount { get; set; }

    [Required]
    public int Dept_Id { get; set; }
    public DepartmentClass DepartmentObject { get; set; }
}
}