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


namespace Application.Controllers
{
    [Authorize]
    public class SalaryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public SalaryController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> ListSalary()
        {
            var allSalaries = await _dbContext.Salaries.ToListAsync();
            Console.WriteLine("All Salaries: ");
            return View(allSalaries);
        }

        [HttpGet]
        public async Task<IActionResult> EditSalary(int id)
        {
            var Salaryrow = await _dbContext.Salaries.FirstOrDefaultAsync(e => e.Sal_Id == id);
            if (Salaryrow == null)
            {
                return NotFound();
            }
            return View(Salaryrow);
        }

        [HttpPost]
        public async Task<IActionResult> EditSalary(SalaryClass salary)
        {
            var salaryInDb = await _dbContext.Salaries.FirstOrDefaultAsync(s => s.Sal_Id == salary.Sal_Id);
            if (salaryInDb != null){
                salaryInDb.SalaryAmount = salary.SalaryAmount;
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("ListSalary", "Salary");
        }
    }
}