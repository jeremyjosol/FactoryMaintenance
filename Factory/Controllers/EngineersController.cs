using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;
    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Engineer> allEngineers = _db.Engineers.ToList();
      return View(allEngineers);
    }

    public ActionResult Create()
    {
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer newEngineer)
    {
      if (!ModelState.IsValid)
      {
        ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
        return View(newEngineer);
      }
      else
      {
        _db.Engineers.Add(newEngineer);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      Engineer selectedEngineer = _db.Engineers
                                     .Include(engineer => engineer.JoinEntities)
                                     .ThenInclude(joinEntity => joinEntity.Machine)
                                     .FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(selectedEngineer);
    }
    public ActionResult Register(int id)
    {
      Engineer engineerToRegister = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(engineerToRegister);
    }

    [HttpPost]
    public ActionResult Register(Machine selectedMachine, Engineer selectedEngineer)
    {
      #nullable enable
      MachineEngineer? joinEntity = _db.MachineEngineers.FirstOrDefault(join => (join.MachineId == selectedMachine.MachineId && join.EngineerId == selectedEngineer.EngineerId));
      #nullable disable
      if (joinEntity == null && selectedMachine.MachineId != 0)
      {
        _db.MachineEngineers.Add(new MachineEngineer() { MachineId = selectedMachine.MachineId, EngineerId = selectedEngineer.EngineerId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = selectedEngineer.EngineerId });
    }

    public ActionResult Delete(int id)
    {
      Engineer selectedEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(selectedEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Engineer selectedEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      _db.Engineers.Remove(selectedEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Engineer selectedEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(selectedEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer)
    {
      _db.Engineers.Update(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}