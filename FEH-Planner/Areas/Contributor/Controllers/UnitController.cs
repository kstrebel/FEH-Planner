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
        private FEHPlannerContext ctx;

        public UnitController(FEHPlannerContext context)
        {
            ctx = context;
        }

        // GET: Contributor/Unit
        public async Task<IActionResult> Index()
        {
            return View(await ctx.Units.ToListAsync());
        }

        // GET: Contributor/Unit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await ctx.Units
                .FirstOrDefaultAsync(m => m.UnitID == id);
            if (unit == null)
            {
                return NotFound();
            }

            return View(unit);
        }

        // GET: Contributor/Unit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contributor/Unit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnitID,Name,Epithet,Entry1,Entry2,MovementType,WeaponType,SpecialType,Availability,LowestRarity")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                ctx.Add(unit);
                await ctx.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unit);
        }

        // GET: Contributor/Unit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await ctx.Units.FindAsync(id);
            if (unit == null)
            {
                return NotFound();
            }
            return View(unit);
        }

        // POST: Contributor/Unit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UnitID,Name,Epithet,Entry1,Entry2,MovementType,WeaponType,SpecialType,Availability,LowestRarity")] Unit unit)
        {
            if (id != unit.UnitID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ctx.Update(unit);
                    await ctx.SaveChangesAsync();
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
            return View(unit);
        }

        // GET: Contributor/Unit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await ctx.Units
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
            var unit = await ctx.Units.FindAsync(id);
            ctx.Units.Remove(unit);
            await ctx.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitExists(int id)
        {
            return ctx.Units.Any(e => e.UnitID == id);
        }
    }
}
