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
    public class SkillController : Controller
    {
        private readonly FEHPlannerContext ctx;

        public SkillController(FEHPlannerContext context)
        {
            ctx = context;
        }

        // GET: Contributor/Skill
        public async Task<IActionResult> Index()
        {

            //return View(skill);
            return View(await ctx.Skills.ToListAsync());
        }

        // GET: Contributor/Skill/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = await ctx.Skills
                .FirstOrDefaultAsync(m => m.SkillID == id);
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        // GET: Contributor/Skill/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contributor/Skill/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SkillID,Name,Slot,SP,Description,Inheritable")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                ctx.Add(skill);
                await ctx.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skill);
        }

        // GET: Contributor/Skill/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = await ctx.Skills.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }
            return View(skill);
        }

        // POST: Contributor/Skill/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SkillID,Name,Slot,SP,Description,Inheritable")] Skill skill)
        {
            if (id != skill.SkillID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ctx.Update(skill);
                    await ctx.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillExists(skill.SkillID))
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
            return View(skill);
        }

        // GET: Contributor/Skill/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = await ctx.Skills
                .FirstOrDefaultAsync(m => m.SkillID == id);
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        // POST: Contributor/Skill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skill = await ctx.Skills.FindAsync(id);
            ctx.Skills.Remove(skill);
            await ctx.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkillExists(int id)
        {
            return ctx.Skills.Any(e => e.SkillID == id);
        }
    }
}
