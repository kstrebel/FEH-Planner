using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FEH_Planner.Models;

namespace FEH_Planner.Controllers
{
    public class HomeController : Controller
    {
        private FEHPlannerContext context { get; set; }

        public HomeController(FEHPlannerContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var builds = context.Builds
                .Include(b => b.Unit).OrderBy(b => b.Name)
                .Include(b => b.Weapon).OrderBy(b => b.Weapon.Name)
                .Include(b => b.A_Skill).OrderBy(b => b.A_Skill.Name)
                .Include(b => b.B_Skill).OrderBy(b => b.B_Skill.Name)
                .Include(b => b.C_Skill).OrderBy(b => b.C_Skill.Name)
                .Include(b => b.S_Skill).OrderBy(b => b.S_Skill.Name)
                .ToList();
            return View(builds);
        }
    }
}