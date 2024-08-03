using Application.Models.Entities.Department;
using Application.Models.Entities.Employee;
namespace Application.Models.Entities.Employee
{
    public class AddEmployeeViewModel
    {
        public Application.Models.Entities.Employee.AddEmployeeModel Employee { get; set; }
        public List<Application.Models.Entities.Department.DepartmentClass> Departments { get; set; }
    }
}