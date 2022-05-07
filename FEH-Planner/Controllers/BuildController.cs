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
            var build = context.Builds.Include(b => b.Unit)
                .Include(b => b.Weapon)
                .Include(b => b.A_Skill)
                .Include(b => b.B_Skill)
                .Include(b => b.C_Skill)
                .Include(b => b.S_Skill)
                .FirstOrDefault(b => b.BuildID == id);
            return View(build);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Units = context.Units.OrderBy(b => b.Name).ToList();
            ViewBag.Weapons = context.Skills.Where(s => s.SlotID == 1).OrderBy(w => w.Name).ToList();
            ViewBag.A_Skills = context.Skills.Where(s => s.SlotID == 4).OrderBy(a => a.Name).ToList();
            ViewBag.B_Skills = context.Skills.Where(s => s.SlotID == 5).OrderBy(b => b.Name).ToList();
            ViewBag.C_Skills = context.Skills.Where(s => s.SlotID == 6).OrderBy(c => c.Name).ToList();
            ViewBag.S_Skills = context.Skills.Where(s => s.SlotID == 7).OrderBy(s => s.Name).ToList();
            return View("Edit", new Build());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Units = context.Units.OrderBy(b => b.Name).ToList();
            ViewBag.Weapons = context.Skills.Where(s => s.SlotID == 1).OrderBy(w => w.Name).ToList();
            ViewBag.A_Skills = context.Skills.Where(s => s.SlotID == 4).OrderBy(a => a.Name).ToList();
            ViewBag.B_Skills = context.Skills.Where(s => s.SlotID == 5).OrderBy(b => b.Name).ToList();
            ViewBag.C_Skills = context.Skills.Where(s => s.SlotID == 6).OrderBy(c => c.Name).ToList();
            ViewBag.S_Skills = context.Skills.Where(s => s.SlotID == 7).OrderBy(s => s.Name).ToList();

            var build = context.Builds.Include(b => b.Unit)
                .Include(b => b.Weapon)
                .Include(b => b.A_Skill)
                .Include(b => b.B_Skill)
                .Include(b => b.C_Skill)
                .Include(b => b.S_Skill)
                .FirstOrDefault(b => b.BuildID == id);
            return View(build);
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

                return RedirectToAction("Index", "Home"); //go to home controller, index action
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Units = context.Units.OrderBy(b => b.Name).ToList();
                ViewBag.Weapons = context.Skills.Where(s => s.SlotID == 1).OrderBy(w => w.Name).ToList();
                ViewBag.A_Skills = context.Skills.Where(s => s.SlotID == 4).OrderBy(a => a.Name).ToList();
                ViewBag.B_Skills = context.Skills.Where(s => s.SlotID == 5).OrderBy(b => b.Name).ToList();
                ViewBag.C_Skills = context.Skills.Where(s => s.SlotID == 6).OrderBy(c => c.Name).ToList();
                ViewBag.S_Skills = context.Skills.Where(s => s.SlotID == 7).OrderBy(s => s.Name).ToList();
                return View(build);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var build = context.Builds.Include(b => b.Unit)
                .Include(b => b.Weapon)
                .Include(b => b.A_Skill)
                .Include(b => b.B_Skill)
                .Include(b => b.C_Skill)
                .Include(b => b.S_Skill).FirstOrDefault(b => b.BuildID == id);
            return View(build);
        }

        [HttpPost]
        public IActionResult Delete(Build build)
        {
            context.Builds.Remove(build);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
