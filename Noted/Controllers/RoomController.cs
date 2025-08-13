using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // For HttpContext and session extension methods
using Noted.Data;
using Noted.Models;

namespace Noted.Controllers;

public class RoomController : Controller
{
    private readonly ILogger<RoomController> _logger;
    private readonly AppDbContext _context;
    public RoomController(ILogger<RoomController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context; // Assuming AppDbContext is set up correctly
    }

    [HttpGet]
    [Route("rooms")]
    public IActionResult GetAll() // after this is called the view of all rooms will be displayed
    {
        var rooms = _context.Rooms.ToList();
        return View("GetAll", rooms);
    }

    [HttpGet]
    [Route("rooms/{roomNumber}")] // this should be the first step before editing the room
    public IActionResult GetOne(int roomNumber)
    {
        // Logic to retrieve room details by number
        var room = _context.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
        if (room == null)
        {
            return NotFound();
        }
        return View("GetOne", room);
    }
    [HttpPost]
    [Route("rooms/edit")]
    public IActionResult EditRoom(Room updatedRoom)
    {
        Console.WriteLine("Editing room: " + " with data: " + updatedRoom.RoomNumber);
        var room = _context.Rooms.FirstOrDefault(r => r.RoomNumber == updatedRoom.RoomNumber);
        if (room == null)
        {
            return NotFound();
        }

        // Update the room properties
        room.RoomNumber = updatedRoom.RoomNumber;
        room.RoomPrice = updatedRoom.RoomPrice;
        room.RoomLocation = updatedRoom.RoomLocation;
        room.RoomCapacity = updatedRoom.RoomCapacity;

        _context.SaveChanges();
        return RedirectToAction("GetAll");
    }
    [HttpGet]
    [Route("rooms/add")]
    public IActionResult AddRoom()
    {
        return View("AddRoom");
    }

    [HttpPost]
    [Route("rooms/add")]
    public IActionResult AddRoom(Room room)
    {
        Console.WriteLine("Adding room: " + room.RoomNumber);
        if (ModelState.IsValid)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return RedirectToAction("GetAll");
        }
        foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
        {
            Console.WriteLine(error.ErrorMessage); // Log to console or debugger
        }

        return View("AddRoom");
    }
    [HttpPost]
    [Route("rooms/delete/{roomNumber}")]
    public IActionResult DeleteRoom(int roomNumber)
    {
        Console.WriteLine("Deleting room: " + roomNumber);
        var room = _context.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
        if (room == null)
        {
            return NotFound();
        }

        _context.Rooms.Remove(room);
        _context.SaveChanges();
        return RedirectToAction("GetAll");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}