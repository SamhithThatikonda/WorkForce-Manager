using Application.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Application.Data;
using Application.Models.Entities.Salary;
using Application.Models.Entities.Employee;
using Application.Models.Entities.Department;
using Application.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Application.Models;

namespace Application.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> AddEmployee()
        {
            var viewModel = new AddEmployeeViewModel
            {
                Employee = new Application.Models.Entities.Employee.AddEmployeeModel(),
                Departments = await _dbContext.Departments.ToListAsync()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeViewModel model)
        {
                var employee = new EmployeeClass
                {
                    First_Name = model.Employee.First_Name,
                    Last_Name = model.Employee.Last_Name,
                    Dept_Id = model.Employee.Dept_Id
                };
                await _dbContext.Employees.AddAsync(employee);
                await _dbContext.SaveChangesAsync();

                var salary = new SalaryClass
                {
                    SalaryAmount = model.Employee.SalaryAmount,
                    Emp_Id = employee.Emp_Id
                };

                await _dbContext.Salaries.AddAsync(salary);
                await _dbContext.SaveChangesAsync();
            
            return RedirectToAction("ListEmployee", "Employee");
        }

        [HttpGet]
        public async Task<IActionResult> ListEmployee(int pg = 1)
        {
        //Client Side Pagination
            // List<EmployeeClass> allemployees = await _dbContext.Employees.ToListAsync();

            // const int pageSize = 10;
            // int recsCount = allemployees.Count;
            // var pager = new Pager(allemployees.Count, pg, pageSize);
            // int recSkip = (pg - 1) * pageSize;

            // var EmployeesData = allemployees.Skip(recSkip).Take(pageSize).ToList();
            // this.ViewBag.Pager = pager;

            // return View(EmployeesData);
            // // return View(allemployees);

        // Server Side Pagination
            int totalEmployees = await _dbContext.Employees.CountAsync();
            int pageSize = 15;

            var employees = await _dbContext.Employees.Skip((pg - 1) * pageSize).Take(pageSize).ToListAsync();

            var pager = new Pager(totalEmployees, pg, pageSize);
            this.ViewBag.Pager = pager;

            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)  
        {        
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Emp_Id == id);
            if (employee == null)
            {
                return NotFound();
            }
        
            var viewModel = new EditEmployeeViewModel
            {
                Employees = employee,
                Departments = await _dbContext.Departments.ToListAsync()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EditEmployeeViewModel employee)
        {
            if (employee == null || employee.Employees == null)
                {
                    return BadRequest("Invalid employee data.");
                }

            var employeeInDb = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Emp_Id == employee.Employees.Emp_Id);
            if (employeeInDb != null){
                employeeInDb.First_Name = employee.Employees.First_Name;
                employeeInDb.Last_Name = employee.Employees.Last_Name;
                employeeInDb.Dept_Id = employee.Employees.Dept_Id;
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("ListEmployee", "Employee");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(EmployeeClass employee)
        {
            Console.WriteLine("testing");
            Console.WriteLine(employee.Emp_Id);
            var employeeRemove = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Emp_Id == employee.Emp_Id);

            if (employeeRemove != null)
            {
                Console.WriteLine("testing");
                _dbContext.Employees.Remove(employeeRemove);
                await _dbContext.SaveChangesAsync();
            }

            var salaryRemove = await _dbContext.Salaries.FirstOrDefaultAsync(s => s.Emp_Id == employee.Emp_Id);
            if (salaryRemove != null)
            {
                _dbContext.Salaries.Remove(salaryRemove);
                await _dbContext.SaveChangesAsync();
            }

            var AuthRemove = await _dbContext.Auths.FirstOrDefaultAsync(a => a.Emp_Id == employee.Emp_Id);
            if (AuthRemove != null)
            {
                _dbContext.Auths.Remove(AuthRemove);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("ListEmployee", "Employee");
        }

    }
}
