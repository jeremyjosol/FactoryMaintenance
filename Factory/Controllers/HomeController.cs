using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
  public class HomeController : Controller
  {
    private readonly FactoryContext _db;
    public HomeController(FactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      ViewBag.MachineEngineers = _db.MachineEngineers.ToList();
      ViewBag.Engineers = _db.Engineers.ToList();
      ViewBag.Machines = _db.Machines.ToList();
      return View();
    }
  }
}