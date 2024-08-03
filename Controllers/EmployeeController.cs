using Application.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Application.Data;
using Application.Models.Entities.Employee;
using Application.Models.Entities.Department;
using Application.Models;


namespace Application.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new EmployeeClass
                {
                    First_Name = model.First_Name,
                    Last_Name = model.Last_Name,
                    Dept_Id = model.Dept_Id
                };
                await _dbContext.Employees.AddAsync(employee);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ListEmployee()
        {
            var allemployees = await _dbContext.Employees.ToListAsync();
            return View(allemployees);
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Emp_Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EmployeeClass employee)
        {
            var employeeInDb = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Emp_Id == employee.Emp_Id);
            if (employeeInDb != null){
                employeeInDb.First_Name = employee.First_Name;
                employeeInDb.Last_Name = employee.Last_Name;
                employeeInDb.Dept_Id = employee.Dept_Id;
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("ListEmployee", "Employee");
        }
    }
}
