using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application.Models.Entities;

namespace Application.Models.Entities.Auth
{
    public class AuthClass
    {
        [Key]
        public int Emp_Id { get; set; }

        [Required]
        public string Password { get; set; }

    }
}