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
    [HttpGet]
    [Route("admin/dashboard")]
    public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetString("AdminLoggedIn") != "true")
        {
            return RedirectToAction("LogIn");
        }
        return View();
    }
    [HttpPost]
    [Route("admin/login")]
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
                return RedirectToAction("Dashboard");
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
    [HttpGet]
    [Route("admin/blogposts/add")]
    public IActionResult AddBlogPost()
    {
        Console.WriteLine("Navigated to AddBlogPost view");
        return View();
    }
    [HttpPost]
    [Route("admin/blogposts/add")]
    public IActionResult AddBlogPost(BlogPost blogPost)
    {
        if (ModelState.IsValid)
        {
            blogPost.CreatedAt = DateTime.Now;
            _context.BlogPosts.Add(blogPost);
            _context.SaveChanges();
            return RedirectToAction("BlogPosts");
        }
        return View("AddBlogPost", blogPost);
    }
    [HttpGet]
    [Route("admin/blogposts")]
    public IActionResult BlogPosts()
    {
        var blogPosts = _context.BlogPosts.ToList();
        return View(blogPosts);
    }
    [HttpGet]
    [Route("admin/blogpost/{id}")]
    public IActionResult BlogPost(int id)
    {
        var blogPost = _context.BlogPosts.FirstOrDefault(bp => bp.Id == id);
        if (blogPost == null)
        {
            ModelState.AddModelError("", "Blog post not found.");
            return View("News");
        }
        return View(blogPost);
    }
}