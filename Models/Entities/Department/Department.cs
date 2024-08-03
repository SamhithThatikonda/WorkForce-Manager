using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models.Entities
{
public class Department
{
    [Key]
    public int Dept_Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Dept_Name { get; set; }
}
}