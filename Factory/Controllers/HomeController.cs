using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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

    }
  }
}