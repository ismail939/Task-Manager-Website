using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // For HttpContext and session extension methods
using Noted.Data;
using Noted.Models;

namespace Noted.Controllers;

public class TableController : Controller
{
    private readonly ILogger<TableController> _logger;
    private readonly AppDbContext _context;
    public TableController(ILogger<TableController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context; // Assuming AppDbContext is set up correctly
    }
    [HttpGet]
    [Route("tables")]
    public IActionResult GetAll() // after this is called the view of all tables will be displayed
    {
        var tables = _context.Tables.ToList();
        return View("GetAll", tables);
    }
    [HttpGet]
    [Route("tables/add")] // this should be the first step before editing the table
    public IActionResult AddTable()
    {
        return View("AddTable");
    }
    [HttpPost]
    [Route("tables/add")]
    public IActionResult AddTable(Table newTable)
    {
        Console.WriteLine("Adding table: " + " with data: " + newTable.TableNumber);
        if (_context.Tables.Any(t => t.TableNumber == newTable.TableNumber))
        {
            ModelState.AddModelError("TableNumber", "This table number already exists.");
        }
        if (ModelState.IsValid)
        {
            _context.Tables.Add(newTable);
            _context.SaveChanges();
            return RedirectToAction("GetAll");
        }
        return View("AddTable", newTable);
    }
    [HttpPost]
    [Route("tables/delete")]
    public IActionResult DeleteTable(int tableNumber)
    {
        Console.WriteLine("Deleting table with Number: " + tableNumber);
        var table = _context.Tables.FirstOrDefault(t => t.TableNumber == tableNumber);
        if (table == null)
        {
            return NotFound();
        }
        _context.Tables.Remove(table);
        _context.SaveChanges();
        return RedirectToAction("GetAll");
    }
}