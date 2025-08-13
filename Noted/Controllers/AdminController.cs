using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Noted.Data;
using Noted.Models;

namespace Noted.Controllers;

public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;
    private readonly AppDbContext _context;
    public AdminController(ILogger<AdminController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    [HttpGet]
    [Route("admin/login")]
    public IActionResult LogIn()
    {
        return View("AdminLogIn");
    }
    [HttpPost]
    [Route("admin/dashboard")]
    public IActionResult Login(Admin admin)
    {
        Console.WriteLine("Attempting to log in with username: " + admin.Username);
        Console.WriteLine("Attempting to log in with password: " + admin.Password);
        if (ModelState.IsValid)
        {
            var existingAdmin = _context.Admins.FirstOrDefault(a => a.Username == admin.Username && a.Password == admin.Password);
            if (existingAdmin != null)
            {
                // Admin login successful, redirect to the admin dashboard 
                HttpContext.Session.SetString("AdminLoggedIn", "true");
                return View("Dashboard");
            }
            ModelState.AddModelError("", "Invalid username or password.");
        }
        return View("AdminLogIn", admin);
    }
    [HttpPost]
    [Route("admin/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("AdminLoggedIn"); // ❌ remove key
        return RedirectToAction("Index", "Home"); // Redirect to home page
    }
}