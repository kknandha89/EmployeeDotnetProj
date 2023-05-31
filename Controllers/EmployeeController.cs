using EmployeeMVC.Models;
using EmployeeMVC.Database;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVC.Controllers;

public class EmployeeController : Controller
{

    private readonly ApplicationDbContext _db;

    public EmployeeController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var employee = _db.Employees.ToList();
        return View(employee);
    }

    public IActionResult Create(EmployeeCls e1)
    {
        return View();
    }

    // public IActionResult RunMigration(EmployeeCls e1)
    // {
    //         ApplicationDbContext.Database.Migrate();
    //         // context.Database.Migrate();
    //         return RedirectToAction("Index");
    // }
    public IActionResult Submit(EmployeeCls e1)
    {
        _db.Add(e1);
        _db.SaveChanges();
        return Ok(e1);
    }

}