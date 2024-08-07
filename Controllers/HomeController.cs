using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cockpit_Local.Models;
using Cockpit_Local.Data;

namespace Cockpit_Local.Controllers;

public class HomeController : Controller
{

    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        List<Users> users = _context.Users.ToList();
        return View(users);
    }

    [HttpGet]
    public IActionResult AddUser()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Users user)
    {
        if (ModelState.IsValid)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index"); // Redirect to a confirmation page or list page
        }
        return View("AddUser"); // If the model is invalid, return the same view with error messages
    }


    public IActionResult Delete(int id)
    {
        var user = _context.Users.Where(x => x.ID == id).FirstOrDefault();
        if (user == null){
            return RedirectToAction("Index");
        }
        _context.Users.Remove(user);
        _context.SaveChanges();
        return RedirectToAction("Index");

    }

    public IActionResult EditUser(int id){
        var user = _context.Users.Where(x => x.ID == id).FirstOrDefault();
        return View(user);
    }

    [HttpPost]
   public IActionResult EditUser(Users users)
        {
        _context.Users.Update(users);
        _context.SaveChanges();
       return RedirectToAction("Index");
    }



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
