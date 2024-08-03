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
    public class DeptController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public DeptController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult AddDept()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDept(AddDeptModel model)
        {
                var department = new DepartmentClass
                {
                    Dept_Name = model.Dept_Name
                };
                await _dbContext.Departments.AddAsync(department);
                await _dbContext.SaveChangesAsync();
            return RedirectToAction("ListDept", "Dept");
        }

        [HttpGet]
        public async Task<IActionResult> ListDept()
        {
            var alldepartments = await _dbContext.Departments.ToListAsync();
            return View(alldepartments);
        }

        [HttpGet]
        public async Task<IActionResult> EditDept(int id)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(e => e.Dept_Id == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        
        [HttpPost]
        public async Task<IActionResult> EditDept(DepartmentClass department)
        {
            var deptInDb = await _dbContext.Departments.FirstOrDefaultAsync(d => d.Dept_Id == department.Dept_Id);
            if (deptInDb != null){
                deptInDb.Dept_Name = department.Dept_Name;
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("ListDept", "Dept");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDept(DepartmentClass department)
        {
            
            var deptInDb = await _dbContext.Departments.FirstOrDefaultAsync(d => d.Dept_Id == department.Dept_Id);
            if (deptInDb == null)
            {
                return NotFound();
            }
            _dbContext.Departments.Remove(deptInDb);
            await _dbContext.SaveChangesAsync();

            var employees = await _dbContext.Employees.Where(e => e.Dept_Id == department.Dept_Id).ToListAsync();
            foreach (var employee in employees)
            {
                _dbContext.Employees.Remove(employee);
            }
            await _dbContext.SaveChangesAsync();
                        

            return RedirectToAction("ListDept", "Dept");
        }   

        [HttpGet]
        public IActionResult AddDeptFromEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDeptFromEmployee(AddDeptModel model)
        {
                var department = new DepartmentClass
                {
                    Dept_Name = model.Dept_Name
                };
                await _dbContext.Departments.AddAsync(department);
                await _dbContext.SaveChangesAsync();
            return RedirectToAction("AddEmployee", "Employee");
        }
    }
}