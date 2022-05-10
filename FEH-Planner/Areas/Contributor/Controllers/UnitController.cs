using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FEH_Planner.Models;
using FEH_Planner.Areas.Contributor.Models;

namespace FEH_Planner.Areas.Contributor.Controllers
{
    [Area("Contributor")]
    public class UnitController : Controller
    {
        private readonly FEHPlannerContext context;

        public UnitController(FEHPlannerContext ctx)
        {
            context = ctx;
        }

        // GET: Contributor/Unit
        public IActionResult Index()
        {
            //with viewmodel
            var units = new UnitListViewModel
            {
                Units = context.Units
                .Include(u => u.MoveType).OrderBy(u => u.MoveTypeID)
                .Include(u => u.WeaponType).OrderBy(u => u.WeaponTypeID)
                .ToList()
            };

            return View(units);

            //var units = context.Units
            //    .Include(u => u.MoveType).OrderBy(u => u.MoveTypeID)
            //    .Include(u => u.WeaponType).OrderBy(u => u.WeaponTypeID);
            //
            //return View(await units.ToListAsync());
            //return View(await context.Units.ToListAsync());
        }

        // GET: Contributor/Unit/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = new UnitViewModel
            {
                Unit = context.Units
                .Include(u => u.MoveType)
                .Include(u => u.WeaponType)
                .FirstOrDefault(u => u.UnitID == id)
            };
            
            //var unit = await context.Units
            //    .Include(u => u.MoveType).OrderBy(u => u.MoveTypeID)
            //    .Include(u => u.WeaponType).OrderBy(u => u.WeaponTypeID);

            if (unit == null)
            {
                return NotFound();
            }

            return View(unit);
        }

        // GET: Contributor/Unit/Create
        public IActionResult Create()
        {
            ViewBag.Action = "Add";

            var model = new UnitViewModel
            {
                Unit = new Unit { UnitID = 0 },
                MoveTypes = context.MoveTypes.OrderBy(u => u.MoveTypeID).ToList(),
                WeaponTypes = context.WeaponTypes.OrderBy(u => u.WeaponTypeID).ToList()
            };

            return View("Edit", model);

            //ViewBag.MoveTypes = context.MoveTypes.OrderBy(u => u.MoveTypeID).ToList();
            //ViewBag.WeaponTypes = context.WeaponTypes.OrderBy(u => u.WeaponTypeID).ToList();
            //return View("Edit", new Unit());
            //return View();
        }

        // GET: Contributor/Unit/Edit/5
        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "Edit";

            if (id == null)
            {
                return NotFound();
            }

            var model = new UnitViewModel
            {
                Unit = context.Units.FirstOrDefault(u=>u.UnitID==id),
                MoveTypes = context.MoveTypes.OrderBy(u => u.MoveTypeID).ToList(),
                WeaponTypes = context.WeaponTypes.OrderBy(u => u.WeaponTypeID).ToList()
            };

            //var unit = await context.Units.FindAsync(id);
            
            if (model == null)
            {
                return NotFound();
            }

            //ViewBag.MoveTypes = context.MoveTypes.OrderBy(u => u.MoveTypeID).ToList();
            //ViewBag.WeaponTypes = context.WeaponTypes.OrderBy(u => u.WeaponTypeID).ToList();

            return View(model);
        }

        // POST: Contributor/Unit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Unit unit)
        {
            //if (id != unit.UnitID)
            //{
            //    return NotFound();
            //}

            string action = (unit.UnitID == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                try
                {
                    if (action == "Add")
                    {
                        context.Units.Add(unit);
                    }
                    else
                    {
                        context.Update(unit);
                    }
                    await context.SaveChangesAsync();

                    TempData["alert"] = $"{action}ed unit \"{unit.Name}: {unit.Epithet}\".";
                    TempData["alert class"] = "success";
                    return RedirectToAction("Details", "Unit", new { ID = unit.UnitID });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitExists(unit.UnitID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["alert"] = $"There was a problem validating the unit. Please try again.";
                TempData["alert class"] = "danger";
                return RedirectToAction("Edit", new { ID = unit.UnitID });

                //ViewBag.Action = action;
                //ViewBag.MoveTypes = context.MoveTypes.OrderBy(u => u.MoveTypeID).ToListAsync();
                //ViewBag.WeaponTypes = context.WeaponTypes.OrderBy(u => u.WeaponTypeID).ToListAsync();
                //return View(unit);
            }
        }

        // GET: Contributor/Unit/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model= new UnitViewModel
            {
                Unit = context.Units
                .Include(u=>u.MoveType)
                .Include(u=>u.WeaponType)
                .FirstOrDefault(u => u.UnitID == id)
            };

            //var unit = await context.Units
            //    .Include(u => u.MoveType)
            //    .Include(u => u.WeaponType)
            //    .FirstOrDefaultAsync(m => m.UnitID == id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Contributor/Unit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(UnitViewModel model)
        {
            string name = context.Units
                .AsNoTracking()
                .FirstOrDefault(u => u.UnitID == model.Unit.UnitID)
                .Name
                + ": " +
                context.Units
                .AsNoTracking()
                .FirstOrDefault(u => u.UnitID == model.Unit.UnitID)
                .Epithet;

            context.Units.Remove(model.Unit);
            context.SaveChanges();

            TempData["alert"] = $"Deleted unit \"{name}\".";
            TempData["alert class"] = "success";
            return RedirectToAction("Index", "Unit");

            //var unit = await context.Units.FindAsync(id);
            //context.Units.Remove(unit);
            //await context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
        }

        private bool UnitExists(int id)
        {
            return context.Units.Any(e => e.UnitID == id);
        }
    }
}
