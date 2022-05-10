using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FEH_Planner.Models;
using System.Collections.Generic;
using System;

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
            //var session = new UserSession(HttpContext.Session);
            //
            //int? count = session.GetMyRecentPagesCount();
            //if (count == null)
            //{
            //    var cookies = new RecentCookies(HttpContext.Request.Cookies);
            //    string[] ids = cookies.GetMyRecentPages();
            //    int[] idInt;
            //
            //    List<Build> myrecents=new List<Build>();
            //    for(int i=0;i<ids.Length;++i)
            //    {
            //        idInt[i] = int.Parse(ids[i]);
            //    }
            //        myrecents = context.Builds.Include(b => b.Name)
            //            .Where(b => b.BuildID==int.Parse(id))
            //            .toList();
            //}

            //with viewmodel
            var data = new BuildListViewModel
            {
                Builds = context.Builds
                    .Include(b => b.Unit).OrderBy(b => b.Name)
                    .Include(b => b.Weapon).OrderBy(b => b.Weapon.Name)
                    .Include(b => b.A_Skill).OrderBy(b => b.A_Skill.Name)
                    .Include(b => b.B_Skill).OrderBy(b => b.B_Skill.Name)
                    .Include(b => b.C_Skill).OrderBy(b => b.C_Skill.Name)
                    .Include(b => b.S_Skill).OrderBy(b => b.S_Skill.Name)
                    .ToList()
            };

            return View(data);
        }
    }
}