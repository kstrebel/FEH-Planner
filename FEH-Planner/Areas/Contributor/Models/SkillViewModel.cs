using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FEH_Planner.Models;

namespace FEH_Planner.Areas.Contributor.Models
{
    public class SkillViewModel
    {
        public Skill Skill { get; set; }

        public List<Slot> Slots { get; set; }
    }
}
