using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FEH_Planner.Models;

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
        public async Task<IActionResult> Index()
        {
            var units = context.Units
                .Include(u => u.MoveType).OrderBy(u => u.MoveTypeID)
                .Include(u => u.WeaponType).OrderBy(u => u.WeaponTypeID);

            return View(await units.ToListAsync());
            //return View(await context.Units.ToListAsync());
        }

        // GET: Contributor/Unit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await context.Units
                .Include(u => u.MoveType)
                .Include(u => u.WeaponType)
                .FirstOrDefaultAsync(u => u.UnitID == id);

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
            ViewBag.MoveTypes = context.MoveTypes.OrderBy(u => u.MoveTypeID).ToListAsync();
            ViewBag.WeaponTypes = context.WeaponTypes.OrderBy(u => u.WeaponTypeID).ToListAsync();
            return View("Edit", new Unit());
            //return View();
        }

        // POST: Contributor/Unit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("UnitID,Name,Epithet,Entry1,Entry2,MovementType,WeaponType,SpecialType,Availability,LowestRarity")] Unit unit)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Add(unit);
        //        await context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(unit);
        //}

        // GET: Contributor/Unit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await context.Units.FindAsync(id);
            if (unit == null)
            {
                return NotFound();
            }

            ViewBag.Action = "Edit";
            ViewBag.MoveTypes = context.MoveTypes.OrderBy(u => u.MoveTypeID).ToListAsync();
            ViewBag.WeaponTypes = context.WeaponTypes.OrderBy(u => u.WeaponTypeID).ToListAsync();

            return View(unit);
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
                    return RedirectToAction("Index", "Unit"); //go to units home
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
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.MoveTypes = context.MoveTypes.OrderBy(u => u.MoveTypeID).ToListAsync();
                ViewBag.WeaponTypes = context.WeaponTypes.OrderBy(u => u.WeaponTypeID).ToListAsync();
                return View(unit);
            }
        }

        // GET: Contributor/Unit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await context.Units
                .FirstOrDefaultAsync(m => m.UnitID == id);
            if (unit == null)
            {
                return NotFound();
            }

            return View(unit);
        }

        // POST: Contributor/Unit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unit = await context.Units.FindAsync(id);
            context.Units.Remove(unit);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitExists(int id)
        {
            return context.Units.Any(e => e.UnitID == id);
        }
    }
}
