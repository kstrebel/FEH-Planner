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
                .Include(b => b.Unit)
                .OrderBy(b => b.Name).ToList();
            return View(builds);
        }
    }
}