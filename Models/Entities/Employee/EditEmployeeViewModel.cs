using Application.Models.Entities.Department;
using Application.Models.Entities.Employee;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Entities.Employee
{
    public class EditEmployeeViewModel
    {   
        [Required]
        public Application.Models.Entities.Employee.EmployeeClass Employees { get; set; }
        [Required]
        public List<Application.Models.Entities.Department.DepartmentClass> Departments { get; set; }
    }
}

