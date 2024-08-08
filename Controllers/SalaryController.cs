using Application.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq;
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
    public class SalaryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public SalaryController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        
        [HttpGet]
        public async Task<IActionResult> ListSalary(int pg = 1, string sortOrder = "Sal_Id")
        {
            // var allSalaries = await _dbContext.Salaries.ToListAsync();
            // Console.WriteLine("All Salaries: ");
            // return View(allSalaries);

            // Server side paging
            int totalSalariesCount = await _dbContext.Salaries.CountAsync();
            int pageSize = 15;


            List<SalaryClass> SalariesRecords = await _dbContext.Salaries.OrderBy(sortOrder).Skip((pg - 1) * pageSize).Take(pageSize).ToListAsync(); 

            var pager = new Pager(totalSalariesCount, pg, pageSize);
            this.ViewBag.Pager = pager;
            this.ViewBag.SortOrder = sortOrder;

            return View(SalariesRecords);

        }

        [HttpGet]
        public async Task<IActionResult> EditSalary1(int id)
        {
            Console.WriteLine("Edit Salary: " + id);
            var Salaryrecord = await _dbContext.Salaries.Where(e => e.Emp_Id == id).OrderByDescending(e => e.Sal_Id).FirstOrDefaultAsync();
            if(Salaryrecord == null){
                return NotFound();
            }
            var salary = new SalaryClass
            {
                Emp_Id = id,
                SalaryAmount = Salaryrecord.SalaryAmount,
                timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff")
            };
            await _dbContext.Salaries.AddAsync(salary);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("ListSalary", "Salary", salary);
        }

        [HttpGet]
        public async Task<IActionResult> EditSalary(int id)
        {
            Console.WriteLine("Edit Salary: " + id);
            var Salaryrecord = await _dbContext.Salaries.OrderBy(e => e.timestamp).FirstOrDefaultAsync(s => s.Sal_Id == id);
            if (Salaryrecord == null)
            {
                return NotFound();
            }
            return View(Salaryrecord);
        }

        [HttpPost]
        public async Task<IActionResult> EditSalary(SalaryClass salary)
        {
            var salaryInDb = await _dbContext.Salaries.OrderBy(e => e.timestamp).FirstOrDefaultAsync(s => s.Sal_Id == salary.Sal_Id);
            if (salaryInDb != null){
                salaryInDb.SalaryAmount = salary.SalaryAmount;
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("ListSalary", "Salary");
        }
    }
}