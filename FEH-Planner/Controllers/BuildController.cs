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
            var build = context.Builds.Include(b => b.Name).FirstOrDefault(b => b.BuildID == id);
            //var weapon = context.Skills.Include(s => s.Name).FirstOrDefault(w => w.WeaponID == id);
            return View(build);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Units = context.Units.OrderBy(b => b.Name).ToList();
            ViewBag.Weapons = context.Skills.Where(s => s.Slot == 'w').OrderBy(w => w.Name).ToList();
            ViewBag.A_Skills = context.Skills.Where(s => s.Slot == 'a').OrderBy(a => a.Name).ToList();
            ViewBag.B_Skills = context.Skills.Where(s => s.Slot == 'b').OrderBy(b => b.Name).ToList();
            ViewBag.C_Skills = context.Skills.Where(s => s.Slot == 'c').OrderBy(c => c.Name).ToList();
            ViewBag.S_Skills = context.Skills.Where(s => s.Slot == 's').OrderBy(s => s.Name).ToList();
            return View("Edit", new Build());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Units = context.Units.OrderBy(b => b.Name).ToList();
            ViewBag.Weapons = context.Skills.Where(s => s.Slot == 'w').OrderBy(w => w.Name).ToList();
            ViewBag.A_Skills = context.Skills.Where(s => s.Slot == 'a').OrderBy(a => a.Name).ToList();
            ViewBag.B_Skills = context.Skills.Where(s => s.Slot == 'b').OrderBy(b => b.Name).ToList();
            ViewBag.C_Skills = context.Skills.Where(s => s.Slot == 'c').OrderBy(c => c.Name).ToList();
            ViewBag.S_Skills = context.Skills.Where(s => s.Slot == 's').OrderBy(s => s.Name).ToList();

            var build = context.Builds.Include(b => b.Name).FirstOrDefault(b => b.BuildID == id);
            return View(build);
        }

        [HttpPost]
        public IActionResult Edit(Build build)
        {
            string action = (build.BuildID == 0) ? "Add" : "Edit";

            build.UnitID = build.Unit.UnitID;

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
                ViewBag.Weapons = context.Skills.Where(s => s.Slot == 'w').OrderBy(w => w.Name).ToList();
                ViewBag.A_Skills = context.Skills.Where(s => s.Slot == 'a').OrderBy(a => a.Name).ToList();
                ViewBag.B_Skills = context.Skills.Where(s => s.Slot == 'b').OrderBy(b => b.Name).ToList();
                ViewBag.C_Skills = context.Skills.Where(s => s.Slot == 'c').OrderBy(c => c.Name).ToList();
                ViewBag.S_Skills = context.Skills.Where(s => s.Slot == 's').OrderBy(s => s.Name).ToList();
                return View(build);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var build = context.Builds.Include(b => b.Name).FirstOrDefault(b => b.BuildID == id);
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
