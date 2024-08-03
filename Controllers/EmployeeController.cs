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
    }
}
