using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Application.Models.Entities
{
public class Employee
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
    public Department DepartmentObject { get; set; }
}
}