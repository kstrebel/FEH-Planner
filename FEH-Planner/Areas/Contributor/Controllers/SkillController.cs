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
        private readonly FEHPlannerContext context;

        public SkillController(FEHPlannerContext ctx)
        {
            context = ctx;
        }

        // GET: Contributor/Skill
        public async Task<IActionResult> Index()
        {
            var skills = context.Skills
                .Include(s => s.Slot).OrderBy(s => s.SlotID);
            return View(skills); //can this be async
            //return View(await context.Skills.ToListAsync());
        }

        // GET: Contributor/Skill/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = await context.Skills
                .Include(s => s.Slot)
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
            ViewBag.Action = "Add";
            ViewBag.Slots = context.Slots.OrderBy(s => s.SlotID).ToList();
            return View("Edit", new Skill());
            //return View();
        }

        // POST: Contributor/Skill/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("SkillID,Name,Slot,SP,Description,Inheritable")] Skill skill)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Add(skill);
        //        await context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(skill);
        //}

        // GET: Contributor/Skill/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = await context.Skills.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            ViewBag.Action = "Edit";
            ViewBag.Slots = context.Slots.OrderBy(s => s.SlotID).ToList();

            return View(skill);
        }

        // POST: Contributor/Skill/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Skill skill)
        {
            string action = (skill.SkillID == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                try
                {
                    if (action == "Add")
                    {
                        context.Skills.Add(skill);
                    }
                    else
                    {
                        context.Update(skill);
                    }

                    await context.SaveChangesAsync();
                    return RedirectToAction("Index", "Skill"); //go to skills home
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
            else
            {
                ViewBag.Action = action;
                ViewBag.Slots = context.Slots.OrderBy(s => s.SlotID).ToList();
                return View(skill);
            }
        }

        // GET: Contributor/Skill/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = await context.Skills
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
            var skill = await context.Skills.FindAsync(id);

            //remove deleted skill from builds
            IQueryable<Build> builds = null;
            string propertyName = "";
            switch (skill.SlotID)
            {
                case 1:
                    builds = context.Builds.OrderBy(b => b.BuildID).Where(b => b.Weapon == skill);
                    propertyName = "Weapon";
                    break;
                //case 2:
                //    builds = context.Builds.OrderBy(b => b.BuildID).Where(b => b.Assist == skill);
                //    propertyName = "Assist";
                //    break;
                //case 3:
                //    builds = context.Builds.OrderBy(b => b.BuildID).Where(b => b.Special == skill);
                //    propertyName = "Special";
                //    break;
                case 4:
                    builds = context.Builds.OrderBy(b => b.BuildID).Where(b => b.A_Skill == skill);
                    propertyName = "A_Skill";
                    break;
                case 5:
                    builds = context.Builds.OrderBy(b => b.BuildID).Where(b => b.B_Skill == skill);
                    propertyName = "B_Skill";
                    break;
                case 6:
                    builds = context.Builds.OrderBy(b => b.BuildID).Where(b => b.C_Skill == skill);
                    propertyName = "C_Skill";
                    break;
                case 7:
                    builds = context.Builds.OrderBy(b => b.BuildID).Where(b => b.S_Skill == skill);
                    propertyName = "S_Skill";
                    break;
            }

            foreach (Build build in builds)
            {
                build.GetType().GetProperty(propertyName).SetValue(build, null);
            }

            context.Skills.Remove(skill);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkillExists(int id)
        {
            return context.Skills.Any(e => e.SkillID == id);
        }
    }
}
