using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FEH_Planner.Models;

namespace FEH_Planner.Controllers
{
    public class BuildController : Controller
    {
        private FEHPlannerContext context { get; set; }

        public BuildController(FEHPlannerContext ctx)
        {
            context = ctx;
        }

        public IActionResult Details(int id)
        {
            var model = new BuildViewModel
            {
                Build = context.Builds.Include(b => b.Unit)
                    .Include(b => b.Weapon)
                    .Include(b => b.A_Skill)
                    .Include(b => b.B_Skill)
                    .Include(b => b.C_Skill)
                    .Include(b => b.S_Skill)
                    .FirstOrDefault(b => b.BuildID == id)
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            var model = new BuildViewModel
            {
                Build = new Build { BuildID = 0 },
                Units = context.Units.OrderBy(b => b.Name).ToList(),
                Weapons = context.Skills.Where(s => s.SlotID == 1).OrderBy(w => w.Name).ToList(),
                A_Skills = context.Skills.Where(s => s.SlotID == 4).OrderBy(a => a.Name).ToList(),
                B_Skills = context.Skills.Where(s => s.SlotID == 5).OrderBy(b => b.Name).ToList(),
                C_Skills = context.Skills.Where(s => s.SlotID == 6).OrderBy(c => c.Name).ToList(),
                S_Skills = context.Skills.Where(s => s.SlotID == 7).OrderBy(s => s.Name).ToList()
            };

            return View("Edit", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            var model = new BuildViewModel
            {
                Build = context.Builds.FirstOrDefault(b => b.BuildID == id),
                Units = context.Units.OrderBy(b => b.Name).ToList(),
                Weapons = context.Skills.Where(s => s.SlotID == 1).OrderBy(w => w.Name).ToList(),
                A_Skills = context.Skills.Where(s => s.SlotID == 4).OrderBy(a => a.Name).ToList(),
                B_Skills = context.Skills.Where(s => s.SlotID == 5).OrderBy(b => b.Name).ToList(),
                C_Skills = context.Skills.Where(s => s.SlotID == 6).OrderBy(c => c.Name).ToList(),
                S_Skills = context.Skills.Where(s => s.SlotID == 7).OrderBy(s => s.Name).ToList()
            };

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Build build)
        {
            string action = (build.BuildID == 0) ? "Add" : "Edit";

            if (build.WeaponID == 0) { build.WeaponID = null; }
            if (build.A_SkillID == 0) { build.A_SkillID = null; }
            if (build.B_SkillID == 0) { build.B_SkillID = null; }
            if (build.C_SkillID == 0) { build.C_SkillID = null; }
            if (build.S_SkillID == 0) { build.S_SkillID = null; }

            //with viewmodel
            if (ModelState.IsValid)
            {
                build.LastModified = DateTime.Now;

                if (action == "Add")
                {
                    context.Builds.Add(build);
                }
                else
                {
                    context.Builds.Update(build);
                }

                context.SaveChanges();

                return RedirectToAction("Details", new { ID = build.BuildID });
            }
            else
            {
                //ViewBag.Action = action;
                return RedirectToAction("Edit", new { ID = build.BuildID });
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = new BuildViewModel
            {
                Build = context.Builds.Include(b => b.Unit)
                    .Include(b => b.Weapon)
                    .Include(b => b.A_Skill)
                    .Include(b => b.B_Skill)
                    .Include(b => b.C_Skill)
                    .Include(b => b.S_Skill)
                    .FirstOrDefault(b => b.BuildID == id)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(BuildViewModel model)
        {
            context.Builds.Remove(model.Build);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
