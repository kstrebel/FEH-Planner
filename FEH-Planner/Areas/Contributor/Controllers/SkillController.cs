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
    public class SkillController : Controller
    {
        private readonly FEHPlannerContext context;

        public SkillController(FEHPlannerContext ctx)
        {
            context = ctx;
        }

        // GET: Contributor/Skill
        public IActionResult Index()
        {
            var skills = new SkillListViewModel
            {
                Skills = context.Skills
                .Include(s => s.Slot).OrderBy(s => s.SlotID)
                .ToList()
            };

            return View(skills);

            //var skills = context.Skills
            //    .Include(s => s.Slot).OrderBy(s => s.SlotID);
            //return View(skills); //can this be async
            //return View(await context.Skills.ToListAsync());
        }

        // GET: Contributor/Skill/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = new SkillViewModel
            {
                Skill = context.Skills
                .Include(s => s.Slot)
                .FirstOrDefault(s => s.SkillID == id)
            };

            //var skill = await context.Skills
            //    .Include(s => s.Slot)
            //    .FirstOrDefaultAsync(m => m.SkillID == id);

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

            var model = new SkillViewModel
            {
                Skill = new Skill { SkillID = 0 },
                Slots = context.Slots.OrderBy(s => s.SlotID).ToList()
            };

            return View("Edit", model);

            //ViewBag.Slots = context.Slots.OrderBy(s => s.SlotID).ToList();
            //return View("Edit", new Skill());
            //return View();
        }

        // GET: Contributor/Skill/Edit/5
        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "Edit";

            if (id == null)
            {
                return NotFound();
            }

            var model = new SkillViewModel
            {
                Skill = context.Skills.FirstOrDefault(s => s.SkillID == id),
                Slots = context.Slots.OrderBy(s => s.SlotID).ToList()
            };

            //var skill = await context.Skills.FindAsync(id);
            
            if (model == null)
            {
                return NotFound();
            }

            //ViewBag.Slots = context.Slots.OrderBy(s => s.SlotID).ToList();

            return View(model);
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

                    TempData["alert"] = $"{action}ed skill \"{skill.Name}\".";
                    TempData["alert class"] = "success";
                    return RedirectToAction("Details", "Skill", new { ID = skill.SkillID }); //go to skills home
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
                //return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["alert"] = $"There was a problem validating the skill. Please try again.";
                TempData["alert class"] = "danger";
                return RedirectToAction("Edit", new { ID = skill.SkillID });

                //ViewBag.Action = action;
                //ViewBag.Slots = context.Slots.OrderBy(s => s.SlotID).ToList();
                //return View(skill);
            }
        }

        // GET: Contributor/Skill/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = new SkillViewModel
            {
                Skill = context.Skills
                .Include(s => s.Slot)
                .FirstOrDefault(s => s.SkillID == id)
            };

            //var skill = await context.Skills
            //    .FirstOrDefaultAsync(m => m.SkillID == id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Contributor/Skill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(SkillViewModel model)
        {
            var skill = await context.Skills.FindAsync(model.Skill.SkillID);
            string name = model.Skill.Name;

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

            TempData["alert"] = $"Deleted skill \"{name}\".";
            TempData["alert class"] = "success";
            return RedirectToAction("Index", "Skill");

            //return RedirectToAction(nameof(Index));
        }

        private bool SkillExists(int id)
        {
            return context.Skills.Any(e => e.SkillID == id);
        }
    }
}
