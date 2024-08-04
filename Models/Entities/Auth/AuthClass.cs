using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application.Models.Entities;

namespace Application.Models.Entities.Auth
{
    public class AuthClass
    {
        [Key]
        [Required(ErrorMessage = "Please enter your Employee ID")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use numbers only please")]
        public int Emp_Id { get; set; }

        [Required (ErrorMessage = "Please enter your Password")]
        public string Password { get; set; }

    }
}