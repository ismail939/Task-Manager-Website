using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Noted.Models;

namespace Noted.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Noted.Data.AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, Noted.Data.AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    [HttpGet]
    [Route("/")]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    [Route("/roompage")]
    public IActionResult RoomPage()
    {
        List<InfoMoney> prices = _context.InfoMonies.ToList();
        return View("Room", prices);
    }
    [HttpGet]
    [Route("/news")]
    public IActionResult News()
    {
        return View();
    }
    [HttpGet]
    [Route("/restaurants")]
    public IActionResult RestaurantPage()
    {
        return View("Restaurants");
    }
    [HttpGet]
    [Route("/halls")]
    public IActionResult HallsPage()
    {
        return View("Halls");
    }
    [HttpGet]
    [Route("/about")]
    public IActionResult AboutPage()
    {
        return View("About");
    }
    [HttpGet]
    [Route("/blogposts")]
    public IActionResult BlogPosts()
    {
        var blogPosts = _context.BlogPosts.ToList();
        return View(blogPosts);
    }
    [HttpGet]
    [Route("/blogpost/{id}")]
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
    
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
