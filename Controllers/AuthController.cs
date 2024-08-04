using Application.Models.Entities.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Application.Data;
using Application.Models;
using Application.Models.Entities.Employee;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Application.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public AuthController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Login()
        {

            if (TempData["Message"] != null){
                ViewBag.Message = TempData["Message"];
            }
            ViewBag.loggedIn = "false";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthClass model)
        {
            TempData["loggedIn"] = "false";
            var employeepresent = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Emp_Id == model.Emp_Id);
            if (employeepresent == null)
            {
                TempData["Message"] = "Employee not found";
                return RedirectToAction("Login", "Auth");
            }
            var userpresent = await _dbContext.Auths.FirstOrDefaultAsync(u => u.Emp_Id == model.Emp_Id);
            if (userpresent == null)
            {
                TempData["Message"] = "Register First";
                return RedirectToAction("Register", "Auth");
            }

            var user = await _dbContext.Auths.FirstOrDefaultAsync(u => u.Emp_Id == model.Emp_Id && u.Password == model.Password);
            if (user == null)
            {
                TempData["Message"] = "Invalid Password";
                return RedirectToAction("Login", "Auth");
            }
            // ViewBag.loggedIn = "true";
            TempData["loggedIn"] = "true";
            return RedirectToAction("ListEmployee", "Employee");
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AuthClass model)
        {
            var employeepresent = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Emp_Id == model.Emp_Id);
            if (employeepresent == null)
            {
                TempData["Message"] = "Employee not found";
                return RedirectToAction("Login", "Auth");
            }
            var userpresent = await _dbContext.Auths.FirstOrDefaultAsync(u => u.Emp_Id == model.Emp_Id);
            if (userpresent != null)
            {
                TempData["Message"] = "User already exists";
                return RedirectToAction("Login", "Auth");
            }
            var user = new AuthClass
            {
                Emp_Id = model.Emp_Id,
                Password = model.Password
            };
            _dbContext.Database.OpenConnection(); // Open the database connection
            _dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT AuthTable ON"); // Enable IDENTITY_INSERT for the table
            await _dbContext.Auths.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            _dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT AuthTable OFF"); // Disable IDENTITY_INSERT for the table
            _dbContext.Database.CloseConnection(); // Close the database connection
        
            TempData["Message"] = "Registered Successfully";
            return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            TempData["loggedIn"] = "false";
            TempData["Message"] = "Logged Out";
            return RedirectToAction("Login", "Auth");
        }
    } 
}