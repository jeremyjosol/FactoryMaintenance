using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;
    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Machine> allMachines = _db.Machines.ToList();
      return View(allMachines);
    }

    public ActionResult Create()
    {
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine newMachine)
    {
      if (!ModelState.IsValid)
      {
        ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
        return View(newMachine);
      }
      else
      {
        _db.Machines.Add(newMachine);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }
    
    public ActionResult Details(int id)
    {
      Machine selectedMachine = _db.Machines
                                   .Include(machine => machine.JoinEntities)
                                   .ThenInclude(joinEntity => joinEntity.Engineer)
                                   .FirstOrDefault(machine => machine.MachineId == id);
      return View(selectedMachine);
    }

    public ActionResult Register(int id)
    {
      Machine machineToRegister = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(machineToRegister);
    }

    [HttpPost]
    public ActionResult Register(Engineer selectedEngineer, Machine selectedMachine)
    {
      #nullable enable
      MachineEngineer? joinEntity = _db.MachineEngineers.FirstOrDefault(join => (join.EngineerId == selectedEngineer.EngineerId && join.MachineId == selectedMachine.MachineId));
      #nullable disable
      if (joinEntity == null && selectedEngineer.EngineerId != 0)
      {
        _db.MachineEngineers.Add(new MachineEngineer() { EngineerId = selectedEngineer.EngineerId, MachineId = selectedMachine.MachineId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = selectedMachine.MachineId });
    }
  }
}