using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FEH_Planner.Models;

namespace FEH_Planner.Areas.Contributor.Controllers
{
    [Area("Contributor")]
    public class HomeController : Controller
    {
        private FEHPlannerContext context { get; set; }

        public HomeController(FEHPlannerContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var skills = context.Skills
                .Include(s => s.Slot).OrderBy(s => s.Slot.Name)
                .ToList();

            //var units = context.Units
                //.ToList();

            return View(skills); //maps to /Areas/Contributor/Views/Home/Index.cshtml
        }
    }
}
