using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FEH_Planner.Models
{
    public class BuildViewModel
    {
        public Build Build { get; set; }

        public List<Unit> Units { get; set; }
        public List<Skill> Weapons { get; set; }
        public List<Skill> A_Skills { get; set; }
        public List<Skill> B_Skills { get; set; }
        public List<Skill> C_Skills { get; set; }
        public List<Skill> S_Skills { get; set; }
    }
}
