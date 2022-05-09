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
        //public int BuildID { get; set; }
        //
        //public DateTime LastModified { get; set; }
        //
        //public string Name { get; set; }
        //
        //public int UnitID { get; set; } //do i need the foreign key IDs
        //public Unit Unit { get; set; }
        //
        //public int? WeaponID { get; set; }
        //public Skill Weapon { get; set; }
        //
        //public int? A_SkillID { get; set; }
        //public Skill A_Skill { get; set; }
        //
        //public int? B_SkillID { get; set; }
        //public Skill B_Skill { get; set; }
        //
        //public int? C_SkillID { get; set; }
        //public Skill C_Skill { get; set; }
        //
        //public int? S_SkillID { get; set; }
        //public Skill S_Skill { get; set; }
    }
}
