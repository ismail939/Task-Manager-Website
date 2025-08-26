using Microsoft.AspNetCore.Mvc;
using Noted.Data;
using Noted.Models;

namespace Noted.Controllers;

public class BlogPostController : Controller
{
    private readonly ILogger<BlogPostController> _logger;
    private readonly AppDbContext _context;
    public BlogPostController(ILogger<BlogPostController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    
}