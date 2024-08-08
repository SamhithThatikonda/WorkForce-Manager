using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application.Models.Entities.Employee;
using Application.Models;
namespace Application.Models
{
    public class RoleClass
    {
        [Key]
        public int Role_Id {get; set;}
        [Required]
        public string Role_Name {get; set;}
        [Required]
        [ForeignKey("Emp_Id")]
        public int Emp_Id {get; set;}  
        public EmployeeClass EmployeeObject { get; set; }

    }
}